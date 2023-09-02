using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
// using Microsoft.Unity.VisualStudio.Editor;

namespace ShopUIAmongUs
{
    public class UIItem : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI priceitemText;
        [SerializeField] Sprite iconImage;
        public Purchase purchase;
        public void SetData(UIItem_Data data)
        {            
            priceitemText.text = data.itemData.price.ToString();     
            purchase.itemcost = data.itemData.price;
            // iconImage = data.itemData.icon();  
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