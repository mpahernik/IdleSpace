using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Node", menuName ="Node")]
public class Node : ScriptableObject
{
    public int Level;
    public float Cost;
    public string Name;
    public float Income;
    public Sprite Image;
    public float CostIcrease;
    public enum type{
        Energy,
        Science
    };
    public type ResourceType;

    public enum costtype
    {
        Energy,
        Science
    };
    public costtype CostType;

    
}
