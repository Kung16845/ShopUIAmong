using System.Collections;
using System.Collections.Generic;
// using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace ShopUIAmongUs
{
    public class UIShop : UIShopAbstraction
    {
        private void Start()
        {
            itemShopUIPrefab.gameObject.SetActive(false);
        }

    }
}