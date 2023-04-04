using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Display : MonoBehaviour
{
    public TextMeshProUGUI Incomeperunit;
    public TextMeshProUGUI TotalIncome;
    public TextMeshProUGUI Level;
    public TextMeshProUGUI CostToUpgrade;
    public Image artwork;
    public GameObject[] targetedobj;
    

    void Awake()
    {
       targetedobj = new GameObject[1];
    }

    public void SetNumbers(int incomeperunit, int totalincome, int level, int costtoupgrade,Sprite art, GameObject gameobj)
    {
        if(targetedobj[0] != null)
        {
            targetedobj[0].GetComponent<NodeDisplay>().istargeted = false;
        }
        Incomeperunit.text ="Income per one: " + incomeperunit.ToString();
        TotalIncome.text ="Total Income: " + totalincome.ToString();
        Level.text ="Level" + level.ToString();
        CostToUpgrade.text ="Cost to upgrade: " + costtoupgrade.ToString();
        artwork.GetComponent<Image>().sprite = art;
        targetedobj[0] = gameobj;
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }


}
