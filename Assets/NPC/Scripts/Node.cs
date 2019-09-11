using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Node", menuName = "ScriptableObjects/Node", order = 1)]
public class Node : ScriptableObject
{
    public string sentence;

    public Node[] links;

    public string[] actions;

}
