using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClickerDisplay : MonoBehaviour
{
    [Header("Scriptable Object")]
    public Clicker_Scrip clck;

    [Header("UI Elements")]
    public TextMeshProUGUI Income;
    public Image art;
    public TextMeshProUGUI clickername;
    public Image Fill;

    float _timetofinish;
    [System.NonSerialized]public float _incomeperclick;
    float currentValue = 0f;
    float maxValue;
    bool _finished = true;
     public bool automatic = false;
    public bool _unlocked = false;



    private void Awake()
    {
        if (!_unlocked)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
        //setting UI Elements
        art.sprite = clck.Image;
        Income.text = clck.IncomePerClick.ToString();
        clickername.text = clck.Name;
        //setting other variables
        _timetofinish = clck.TimeToFinish;
        _incomeperclick = clck.IncomePerClick;
        maxValue = _timetofinish;
    }

    private void Start()
    {
        Fill.fillAmount = Normalise();
    }

    private void Update()
    {
        if (!_finished)
        {
            Countdown();
        }
        else
        {
            currentValue = 0f;
            Fill.fillAmount = Normalise();
            if (automatic)
            {
                Restart();
            }
        }
    }

    public void Restart()
    {
        if (_finished)
        {
            _finished = false;
            StartCoroutine(Working());
        }

    }

    public IEnumerator Working()
    {
        yield return new WaitForSeconds(_timetofinish);
        _finished = true;
        IncomeCheck();
    }



    private float Normalise()
    {
        return currentValue / maxValue;
    }

    private void Countdown()
    {
        currentValue += Time.deltaTime;

        if(currentValue >= maxValue)
        {
            currentValue = 0;
        }
        Fill.fillAmount = Normalise();
    }


    public void IncomeCheck()
    {
        if(clck.ResourceType == Clicker_Scrip.type.Energy)
        {
            GameManager.Resource += _incomeperclick;
        }
        else if (clck.ResourceType == Clicker_Scrip.type.Science)
        {
            GameManager.ScienceRes += _incomeperclick;
        }

    }




}
