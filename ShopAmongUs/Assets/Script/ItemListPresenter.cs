using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class InventoryPresenter : MonoBehaviour
{
    int currentItemIndex;
    int currentCategoryIndex;

    /*int maxItemIndex;
    int maxCategoryCount = 4;

    int pageSize = 6;

    [SerializeField] UIInventory UI;
    [SerializeField] Invertory inventory;
    [SerializeField] List<CategoryInfo> CategoryInfoList = new List<CategoryInfo>();*/

    void Start()
    {
        refreshCategory(1);
        RefreshUI();
    }
    
    public void GetCatagory(int CatagoryNumber)
    {
        refreshCategory(CatagoryNumber);
        RefreshUI();
    }
    
    public void GetItemIndex()
    {


        RefreshUI();
    }
   
    void RefreshUI()
    {
       /* var currentCategoryInfo = CategoryInfoList[currentCategoryIndex];
        UI.SetCategory(currentCategoryInfo);

        var currentItem = inventory.Items[currentItemIndex];
        UI.SetCurrentItemInfo(currentItem);

        var currentCategory = (ItemType)currentCategoryIndex;
        var itemToDisplay = inventory.GetItemByType(currentCategory);

        var uiDataList = new List<UIItem_Data>();

        var currentPageIndex = currentItemIndex / pageSize;
        var StartIndexToDisplay = currentPageIndex * pageSize;
        var EndIndexToDisplay = StartIndexToDisplay + pageSize;

        var i = 0;
        foreach (var item in itemToDisplay)
        {
            if (i >= StartIndexToDisplay && i < EndIndexToDisplay)
                uiDataList.Add(new UIItem_Data(item, currentItem == item));

            i++;
        }

        maxItemIndex = itemToDisplay.Length;
        UI.SetItemList(uiDataList.ToArray());*/
    }


    [SerializeField] List<CategoryData> CategoryList = new List<CategoryData>();
    void refreshCategory(int CatagoryNumber)
    {
        foreach (CategoryData ThisCategory in CategoryList)
        {
            if ((int)ThisCategory.Type == CatagoryNumber)
            {
                ThisCategory.Header.SetActive(true);
            }
            else
            {
                ThisCategory.Header.SetActive(false);
            }
        }
    }

    [Serializable]
    public class CategoryData
    {
        public GameObject Header;
        public CategoryType Type;
    }
}