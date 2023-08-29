using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Playermoney : MonoBehaviour
{
    public TMP_Text moneyText;
    public int currentmoney = 50000;
    void Update()
    {
        UpdateMoneyText();
    }
    public void UpdateMoneyText()
    {
        moneyText.text = "Money: $" + currentmoney.ToString();
    }
}
