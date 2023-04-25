using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BoosterDisplay : MonoBehaviour
{
    [Header("Scriptable Object")]
    public Booster_Script boostr;

    [Header("UI Elements")]
    public TextMeshProUGUI effecttext;
    public Image art;
    public TextMeshProUGUI boostername;
    public TextMeshProUGUI costtext;
    

    [Header("Miscalenious")]
    public GameObject[] Tounlock;
    public GameObject target;
    public bool _unlocked = false;
    float increaseamount;
    float cost;
    float costinc;
    float _resourcecheck;


    public void Awake()
    {
        if (!_unlocked)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        art.sprite = boostr.Image;
        boostername.text = boostr.BoosterName;
        costtext.text = boostr.Cost.ToString();

        increaseamount = boostr.IncreaseAmount;
        cost = boostr.Cost;
        costinc = boostr.CostIncrease;

        


    }

    public void ClickedOn()
    {
        //check what resource to dedeuct
        switch (boostr.Costtype)
        {
            case Booster_Script.costtype.Energy:
                _resourcecheck = GameManager.Resource;
                break;
            case Booster_Script.costtype.Science:
                _resourcecheck = GameManager.ScienceRes;
                break;

        }



        if (_resourcecheck >= cost)
        {
            GameManager.Resource -= cost;
            cost *= costinc;
            costtext.text = cost.ToString();
            Unlock();
            //what does each booster type do
            switch (boostr.Boostertype)
            {
                case (Booster_Script.type.IncomeIncrease):
                    if (target.gameObject.tag == "Clicker")
                    {
                        target.gameObject.GetComponent<ClickerDisplay>()._incomeperclick = target.gameObject.GetComponent<ClickerDisplay>()._incomeperclick + target.gameObject.GetComponent<ClickerDisplay>()._incomeperclick * (increaseamount / 100);
                        target.gameObject.GetComponent<ClickerDisplay>().Income.text = target.gameObject.GetComponent<ClickerDisplay>()._incomeperclick.ToString() ;
                    }
                    else if (target.gameObject.tag == "Node")
                    {
                        target.gameObject.GetComponent<NodeDisplay>().incomeperlvl = target.gameObject.GetComponent<NodeDisplay>().incomeperlvl + ((increaseamount / 100) * target.gameObject.GetComponent<NodeDisplay>().incomeperlvl);
                        target.gameObject.GetComponent<NodeDisplay>().Recalculate(increaseamount);
                    }

                    break;
                case (Booster_Script.type.TimeReduction):
                    Debug.Log("tu tu");



                    break;

                case (Booster_Script.type.Automation):

                    if (target.gameObject.tag == "Clicker")
                    {
                        target.gameObject.GetComponent<ClickerDisplay>().automatic = true;

                    }

                    break;
            }


        }
        else
        {
            NodeDisplay.Nocashbool = true;
        }





    }

    void Unlock()
    {
        foreach (GameObject unlocky in Tounlock)
        {
            unlocky.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            unlocky.gameObject.transform.GetChild(1).gameObject.SetActive(true);

            switch (unlocky.gameObject.tag)
            {
                case ("Node"):
                    unlocky.gameObject.GetComponent<NodeDisplay>()._unlocked = true;
                    break;
                case ("Bonus"):
                    unlocky.gameObject.GetComponent<BoosterDisplay>()._unlocked = true;
                    break;
                case ("Clicker"):
                    unlocky.gameObject.GetComponent<ClickerDisplay>()._unlocked = true;
                    break;


            }


        }
    }


}
