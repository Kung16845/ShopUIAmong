using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using TMPro;
namespace ShopUIAmongUs
{
public class InventoryPresenter : MonoBehaviour
{
    int currentItemIndex;
    public int currentCategoryIndex ;

    [SerializeField] UIShop UIItemShop;
    [SerializeField] ItemList itemList;
    [SerializeField] TextMeshProUGUI textCategory;      

    void Start()
    {
        
        RefreshUI();
    }
    
    public void GetCatagory(int CatagoryNumber)
    {
        refreshCategory(CatagoryNumber);
        currentCategoryIndex = CatagoryNumber;
        textCategory.text = ((CategoryType)CatagoryNumber).ToString();
        RefreshUI();
    }
    
    // public void GetItemIndex()
    // {
    //     RefreshUI();
    // }
    
    private void Update() 
    {
        
    }
    void RefreshUI()
    {
        
        // Fetch items of the current category
        var itemsOfCurrentCategory = itemList.GetItemByType((CategoryType)currentCategoryIndex);

        // Convert these items to UIItem_Data objects (as UIShop expects this format)
        List<UIItem_Data> uiItems = new List<UIItem_Data>();
        foreach (var item in itemsOfCurrentCategory)
        {
            uiItems.Add(new UIItem_Data(item));
        }

        // Update the UIShop to display the fetched items
        UIItemShop.ClearAllItem(); 
        UIItemShop.SetItemShopList(uiItems.ToArray());
    }


    [SerializeField] List<CategoryData> CategoryList = new List<CategoryData>();
    public void refreshCategory(int CatagoryNumber)
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
}