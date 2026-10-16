using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CollectionOfNodes", menuName = "Scriptable Objects/CollectionOfNodes")]
public class CollectionOfNodes : ScriptableObject
{
    public List<Node> nodeList = new();
}
