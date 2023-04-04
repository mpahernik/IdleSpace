using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIDisplay : MonoBehaviour
{
    public TextMeshProUGUI incometext;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI premiumresource;
    public TextMeshProUGUI resource;
    public TextMeshProUGUI premiumres;
    public TextMeshProUGUI Nocashmessage;
    public TextMeshProUGUI Scienceresource;
    public TextMeshProUGUI Scienceincometext;
    float _resource_round;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        incometext.text = "Income: " + GameManager.TotalIncome.ToString();
        Scienceincometext.text = GameManager.ScienceTotalIncome.ToString();
        scoretext.text = GameManager.Score.ToString();
        _resource_round = Mathf.RoundToInt(GameManager.Resource);
        resource.text ="Energy " + _resource_round.ToString();
        _resource_round = Mathf.RoundToInt(GameManager.ScienceRes);
        Scienceresource.text ="Science " + _resource_round.ToString();
        premiumres.text = GameManager.PremiumRes.ToString();

        if (NodeDisplay.Nocashbool)
        {
            Nocashmessage.gameObject.SetActive(true);
            StartCoroutine(FadeTextToZeroAlpha(3f, Nocashmessage.gameObject.GetComponent<TextMeshProUGUI>()));
            NodeDisplay.Nocashbool = false;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
