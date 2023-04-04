using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [System.NonSerialized]public static int Score;
    [System.NonSerialized]public static float TotalIncome;
    [System.NonSerialized]public static float Resource;   
    [System.NonSerialized]public static int PremiumRes;
    [System.NonSerialized] public static float ScienceTotalIncome;
    [System.NonSerialized] public static float ScienceRes;

    float incometimer = .1f;
    float timer;
    void Awake()
    {
        PremiumRes = 0;
        Score = 0;
        TotalIncome = 0f;
        Resource = 0f;
        ScienceRes = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= incometimer)
        {
            Resource += TotalIncome/10;
            ScienceRes += ScienceTotalIncome / 10;
            timer = 0;
           
        }

        
    }
}
