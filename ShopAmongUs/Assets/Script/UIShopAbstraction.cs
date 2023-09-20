using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace ShopUIAmongUs
{
    public abstract class UIShopAbstraction : MonoBehaviour
    {
        [Header("item Shop")]
        [SerializeField] Image imageitemShop;
        [SerializeField] TextMeshProUGUI descriptionitemshop;

        [Header("Item Shop List")]
        public UIItem itemShopUIPrefab;
        [SerializeField] List<UIItem> itemShopUIList = new List<UIItem>();
        public void SetItemShopList(UIItem_Data[] itemShopDatas)
        {
            foreach (var ItemShopUiData in itemShopDatas)
            {
                var newitemShopUI = Instantiate(itemShopUIPrefab, itemShopUIPrefab.transform.parent, false);

                newitemShopUI.gameObject.SetActive(true);
                itemShopUIList.Add(newitemShopUI);
                newitemShopUI.SetData(ItemShopUiData);
            }
        }
        public void ClearAllItem()
        {
            foreach (UIItem itemShopUi in itemShopUIList)
            {
                Destroy(itemShopUi.gameObject);
            }

            itemShopUIList.Clear();
        }
    }

}
