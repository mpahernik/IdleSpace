using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NodeDisplay : MonoBehaviour
{
    [Header("Scriptable Object")]
    public Node Node;

    [Header("UI elements")]
    public TextMeshProUGUI LevelText;
    public TextMeshProUGUI CostText;
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI IncomeText;
    public Image art;
    public GameObject[] Tounlock;
    
    [Header("Miscelaneious")]
    private float _costIncrease;

    private float cost;
    [System.NonSerialized]public float incomeperlvl;
    private int _level;
    public static bool Nocashbool = false;
    float _incomeofnode;
    float _oldincomeofnode;

    public GameObject Display;
    public bool istargeted;
    public bool _unlocked=false;

    float _resourcecheck;

    private void Awake()
    {
        if (!_unlocked)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
    void Start()
    {
        art.sprite = Node.Image;       
        cost = Node.Cost;
        incomeperlvl = Node.Income;
        _level = Node.Level;
        _costIncrease = Node.CostIcrease;

        LevelText.text = _level.ToString();
        CostText.text =  cost.ToString();
        NameText.text = Node.Name;
        IncomeText.text = _incomeofnode.ToString();

        
    }


    public void Levelup()
    {
        if (!istargeted && _unlocked)
        {
            Display.gameObject.SetActive(true);
            istargeted = true;
            Display.GetComponent<Display>().SetNumbers(Mathf.RoundToInt(incomeperlvl), Mathf.RoundToInt(_incomeofnode), _level,Mathf.RoundToInt(cost),art.sprite, this.gameObject);
        }
        else if(istargeted && _unlocked)
        {
            
            //provjeravam koji rsource moram skidat
            switch (Node.CostType)
            {
                case Node.costtype.Energy:
                    _resourcecheck = GameManager.Resource;
                    break;
                case Node.costtype.Science:
                    _resourcecheck = GameManager.ScienceRes;
                    break;
                
            }


            if (_resourcecheck >= cost)
            {
                
                _level += 1;
                _incomeofnode = _level * incomeperlvl;
                IncomeCheck();
                cost *= _costIncrease; 
                cost = Mathf.RoundToInt(cost);
               
                if (_level == 1) Unlock();
            }
            else
            {
                Nocashbool = true;
            }
            LevelText.text = _level.ToString();
            CostText.text = cost.ToString();
            IncomeText.text = _incomeofnode.ToString();
        }
    }  

    public void Recalculate(float multyplyer)
    {
        _oldincomeofnode = _incomeofnode;
        _incomeofnode = _level * incomeperlvl;
        GameManager.TotalIncome += _incomeofnode  - _oldincomeofnode;
        IncomeText.text = _incomeofnode.ToString();
    }

    public void IncomeCheck()
    {
        if (Node.ResourceType == Node.type.Energy)
        {
            GameManager.TotalIncome += _incomeofnode - ((_level - 1) * incomeperlvl);
            GameManager.Resource -= cost;
        }
        else if( Node.ResourceType == Node.type.Science){
            GameManager.ScienceTotalIncome += _incomeofnode - ((_level - 1) * incomeperlvl);
            GameManager.ScienceRes -= cost;
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
