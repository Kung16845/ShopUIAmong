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
    
    public int currentCategoryIndex ;
    public int currentShopPageIndex = 0;
    public int pageSize = 6;
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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pageSize = 6;
            RefreshUI();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pageSize = 9;
            RefreshUI();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            pageSize = 12;
            RefreshUI();
        }
    }
    void RefreshUI()
    {
        
        // Fetch items of the current category
        var itemsOfCurrentCategory = itemList.GetItemByType((CategoryType)currentCategoryIndex);

        int startIndex = currentShopPageIndex * pageSize;
        int endIndex = Mathf.Min(startIndex + pageSize, itemsOfCurrentCategory.Length);

        // Convert these items to UIItem_Data objects (as UIShop expects this format)
        List<UIItem_Data> uiItems = new List<UIItem_Data>();
        
        // foreach (var item in itemsOfCurrentCategory)
        // {
        //      uiItems.Add(new UIItem_Data(item));
        // }
        for (int i = startIndex; i < endIndex; i++)
        {
            uiItems.Add(new UIItem_Data(itemsOfCurrentCategory[i]));
        }
        // ตัดรายการตามจำนวนที่คุณต้องการแสดงในหน้านั้นๆ
        
        // Update the UIShop to display the fetched items
        UIItemShop.ClearAllItem(); 
        UIItemShop.SetItemShopList(uiItems.ToArray());
    }
    public void NextPage()
    {
        // Check if there's a next page
        int totalItems = itemList.GetItemByType((CategoryType)currentCategoryIndex).Length;
        if ((currentShopPageIndex + 1) * pageSize < totalItems)
        {
            currentShopPageIndex++;
            RefreshUI();
        }
    }

    public void PreviousPage()
    {
        if (currentShopPageIndex > 0)
        {
            currentShopPageIndex--;
            RefreshUI();
        }
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