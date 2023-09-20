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
    public class UIItem : UIItemAbstraction , IPointerEnterHandler, IPointerExitHandler 
    {
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
        
}