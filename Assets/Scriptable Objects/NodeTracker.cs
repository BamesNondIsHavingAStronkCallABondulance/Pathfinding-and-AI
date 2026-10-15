using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NodeTracker", menuName = "Scriptable Objects/NodeTracker")]
public class NodeTracker : ScriptableObject
{
    public List<Vector3> nodePositions = new();
}
