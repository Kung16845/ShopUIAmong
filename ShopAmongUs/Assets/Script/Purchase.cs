using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Purchase : MonoBehaviour
{
    public Button buybotton;
    public int itemcost = 0;
    public GameObject playerMoneyObject;
    private Playermoney playerMoneyScript;
    
    void Start()
    {
        playerMoneyScript = playerMoneyObject.GetComponent<Playermoney>();
    }
    public void PurchaseOnClick()
    {
        if (playerMoneyScript.currentmoney >= itemcost)
        {
            playerMoneyScript.currentmoney -= itemcost;
            playerMoneyScript.UpdateMoneyText();
            Debug.Log("Purchase successful!");
        }
        else
        {
            Debug.Log("Not enough money to purchase.");
        }
    }
}

