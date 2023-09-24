using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShopUIAmongUs.Json
{
    [Serializable]
    public class ItemDataJson
    {
        public string displayName;
        public string displayDescription;
        public string icon;
        public int price;
        public CategoryType type;
    }
}