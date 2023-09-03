using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEditor.U2D;
using UnityEngine.EventSystems;
// using Microsoft.Unity.VisualStudio.Editor;

namespace ShopUIAmongUs
{
    public class UIItem : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler 
    {
        [SerializeField] TextMeshProUGUI priceitemText;
        [SerializeField] TextMeshProUGUI ShopItemdescrition;
        [SerializeField] Sprite iconImage; 
        public string description;
        public GameObject gameObjectShop;
        public Purchase purchase;
        public void SetData(UIItem_Data data)
        {            
            priceitemText.text = data.itemData.price.ToString();     
            purchase.itemcost = data.itemData.price;
            iconImage = data.itemData.icon;
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
        public void OnPointerEnter(PointerEventData eventData)
        {
            // เมื่อเมาส์เข้ามาใน UIItem
            ShopItemdescrition.text = description; // ตั้งค่า description ตามข้อมูลใน data
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            // เมื่อเมาส์ออกจาก UIItem
            // ตั้งค่า description กลับไปยังค่าเริ่มต้นหรือให้เป็นค่าว่าง (ตามที่คุณต้องการ)
            ShopItemdescrition.text = ""; 
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