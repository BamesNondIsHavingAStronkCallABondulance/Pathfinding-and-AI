using UnityEngine;

public class NodeFinder : MonoBehaviour
{
    public Node node;
    public CollectionOfNodes collectionOfNodes;

    private void Awake()
    {
        collectionOfNodes.nodeList.Clear();
    }
    void Start()
    {
        node.pos = transform.position;

        collectionOfNodes.nodeList.Add(node);
    }
}
