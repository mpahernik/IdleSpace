using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Clicker", menuName = "Clicker")]
public class Clicker_Scrip : ScriptableObject
{
    public float IncomePerClick;
    public float TimeToFinish;
    public Sprite Image;
    public string Name;
    public enum type
    {
        Energy,
        Science
    };
    public type ResourceType;

    

}
