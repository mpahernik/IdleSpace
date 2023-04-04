using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Booster", menuName = "Booster")]

public class Booster_Script : ScriptableObject {

    public string BoosterName;
    public int Level;
    public float Cost;
    public Sprite Image;
    public float CostIncrease;
    public float IncreaseAmount;
    public enum type
    {
        IncomeIncrease,
        TimeReduction,
        Automation
    };
    public type Boostertype;

    public enum costtype
    {
        Energy,
        Science
    };
    public costtype Costtype;


}
