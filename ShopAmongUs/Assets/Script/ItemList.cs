using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopUIAmongUs
{
    public class ItemList : MonoBehaviour
    {
        public ItemData[] Items => itemList.ToArray();

        public int Lenght { get; internal set; }

        [SerializeField] List<ItemData> itemList = new List<ItemData>();

        public ItemData[] GetItemByType(CategoryType targetType)
        {
            var resultList = new List<ItemData>();
            foreach (var itemData in itemList)
            {
                if (itemData.type == targetType)
                    resultList.Add(itemData);
            }
            return resultList.ToArray();
        }

    }

    [Serializable]
    public class ItemData
    {
        public string displayName;
        public string displayDescription;
        public Sprite icon;
        public int price;
        public CategoryType type;
    }
    public enum CategoryType
    {
        Hats = 1,
        Skins = 2,
        Pets = 3,
        Visors = 4,
        Nameplates = 5
    }
}