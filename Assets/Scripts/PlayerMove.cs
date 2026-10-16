using System.Threading;
using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] private float WalkSpeed = 5.5f;
    [SerializeField] private float RunningSpeed = 9.0f;

    [SerializeField] private float JumpForce = 8.0f;
    [SerializeField] private float Gravity = 20.0f;

    [SerializeField] private float LookSensitivity = 0.2f;
    [SerializeField] private float LookAngleLimit = 90.0f;

    private Camera mainCamera;
    private CharacterController characterController;
    private Rigidbody rigidbody;

    private InputAction moveInput;
    private InputAction runInput;
    private InputAction jumpInput;

    private float currentMoveSpeed = 0f;
    private Vector3 moveDirection = Vector3.zero;
    private float lookAngle = 0f;
    private bool jumped = false;

    float playerHealth;
    int playerScore, playerLives;
    string playerName;

    //public PlayerSO playerData;

    void Start()
    {
        mainCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();
        rigidbody = GetComponent<Rigidbody>();

        moveInput = InputSystem.actions.FindAction("Move");
        runInput = InputSystem.actions.FindAction("Sprint");
        jumpInput = InputSystem.actions.FindAction("Jump");

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        currentMoveSpeed = WalkSpeed;

        //playerHealth = playerData.baseHealth;
        //playerData.currentHealth = playerHealth; //Resets current health, should be saved in player prefs

        //playerScore = playerData.baseScore;
        //playerData.score = playerScore;

        //playerLives = playerData.lives;
        //playerName = playerData.name;

        jumpInput.started += Jumped;
        //gravity = 9.8f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = moveInput.ReadValue<Vector2>();
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        if (!characterController.isGrounded)
            jumped = false;

        currentMoveSpeed = runInput.IsPressed() ? RunningSpeed : WalkSpeed;

        HandleMovement(moveVector);
        HandleLooking(mouseDelta);

        //playerHealth = playerData.currentHealth;
        //playerScore = playerData.score;
        //playerLives = playerData.lives;
        //playerName = playerData.name;

        //UIscript.ui.DrawText("Player health is " + playerHealth + "\n");
        //UIscript.ui.DrawText("Player score is " + playerScore + "\n");
    }

    private void HandleMovement(Vector2 moveVector)
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        float oldY = moveDirection.y;

        Vector2 newSpeed = new Vector2(moveVector.y * currentMoveSpeed, moveVector.x * currentMoveSpeed);

        moveDirection = (forward * newSpeed.x) + (right * newSpeed.y);
        moveDirection.y = (jumped && characterController.isGrounded) ? JumpForce : oldY;

        if (!characterController.isGrounded)
            moveDirection.y -= Gravity * Time.deltaTime;


        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void HandleLooking(Vector2 mouseDelta)
    {
        lookAngle += -mouseDelta.y * LookSensitivity;
        lookAngle = Mathf.Clamp(lookAngle, -LookAngleLimit, LookAngleLimit);

        mainCamera.transform.localRotation = Quaternion.Euler(lookAngle, 0, 0);
        transform.rotation *= Quaternion.Euler(0, mouseDelta.x * LookSensitivity, 0);
    }

    private void Jumped(InputAction.CallbackContext _)
    {
        jumped = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        /*if (collider.gameObject.tag == "Score10")
        {
            playerData.score += 10;
        }
        else if (collider.gameObject.tag == "Score20")
        {
            playerData.score += 20;
        }
        else if (collider.gameObject.tag == "Minus20")
        {
            playerData.score -= 20;
        }
        else if (collider.gameObject.tag == "EndGate")
        {
            SceneManager.LoadScene(1);
        }*/

    }
}
