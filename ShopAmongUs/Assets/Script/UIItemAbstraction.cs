using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEditor.U2D;
using UnityEngine.EventSystems;

namespace ShopUIAmongUs
{
public class UIItemAbstraction : MonoBehaviour
    {
        
    [SerializeField] TextMeshProUGUI priceitemText;
    [SerializeField] Sprite iconImage; 
    [SerializeField] protected TextMeshProUGUI ShopItemdescrition;
    public string description;
    public GameObject gameObjectShop;
    public Purchase purchase;
    
    public void SetData(UIItem_Data data)
        {            
            priceitemText.text = data.itemData.price.ToString();     
            purchase.itemcost = data.itemData.price;
            iconImage = data.itemData.icon;
            Debug.Log("Dataset");
            ShopItemdescrition.text = data.itemData.displayDescription;
            description = data.itemData.displayDescription;   
            Image imageComponent = gameObjectShop.GetComponent<Image>();

            if (imageComponent != null)
            {
                // กำหนด Sprite ใหม่ให้กับ Image component
                imageComponent.sprite = data.itemData.icon;
            }
            else
            {
                Debug.LogWarning("ไม่พบ Image component ใน gameObjectShop");
            }   
        }
    }
    public class UIItem_Data
    {
        public ItemData itemData;

        public UIItem_Data(ItemData itemData)
        {
            this.itemData = itemData;
        }
    }
}