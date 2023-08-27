using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invertory : MonoBehaviour
{
    public ItemData[] Items => itemList.ToArray();
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
    public Sprite icon;
    public int price;
    public CategoryType type;
}
public enum CategoryType
{
    Hats,Skins,Pets,Visors,Nameplates
}