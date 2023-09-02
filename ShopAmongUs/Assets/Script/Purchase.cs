using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
public class Purchase : MonoBehaviour
{
    public Button buybotton;
    public int itemcost = 0;
    public GameObject playerMoneyObject ;
    public Playermoney playerMoneyScript;
    [SerializeField] TextMeshProUGUI price;
    
    void Start()
    {
        playerMoneyObject = GameObject.FindGameObjectWithTag("Money");  
    }
    public void PurchaseOnClick()
    {
        if (playerMoneyScript.currentmoney >= itemcost)
        {
            playerMoneyScript.currentmoney -= this.itemcost;
            playerMoneyScript.UpdateMoneyText();
            Debug.Log("Purchase successful!");
        }
        else
        {
            Debug.Log("Not enough money to purchase.");
        }
    }
}

