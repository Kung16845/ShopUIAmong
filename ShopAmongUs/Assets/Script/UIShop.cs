using System.Collections;
using System.Collections.Generic;
// using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace ShopUIAmongUs
{
public class UIShop : MonoBehaviour
{
    [Header ("item Shop")]
    [SerializeField] Image imageitemShop;
    [SerializeField] TextMeshProUGUI descriptionitemshop;

    [Header ("Item Shop List")]
    [SerializeField] UIItem itemShopUIPrefab;
    [SerializeField] List<UIItem> itemShopUIList = new List<UIItem>();

    private void Start()
    {
        itemShopUIPrefab.gameObject.SetActive(false);
    }
    public void SetItemShopList(UIItem_Data[] itemShopDatas)
    {
        foreach(var ItemShopUiData in itemShopDatas)
        {
            var newitemShopUI = Instantiate(itemShopUIPrefab,itemShopUIPrefab.transform.parent,false);

            newitemShopUI.gameObject.SetActive(true);
            itemShopUIList.Add(newitemShopUI);
            newitemShopUI.SetData(ItemShopUiData);
        }
    }
    public void ClearAllItem()
    {
            foreach(UIItem itemShopUi in itemShopUIList)
            {
                Destroy(itemShopUi.gameObject); 
            }
            
            itemShopUIList.Clear(); 
    }

    
}
}