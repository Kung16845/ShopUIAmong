using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
// using Microsoft.Unity.VisualStudio.Editor;

namespace ShopUIAmongUs
{
    public class UIItem : MonoBehaviour
    {
        [SerializeField] TextMeshPro itemNameText;
        [SerializeField] TextMeshPro countText;
        [SerializeField] Image pointerImage;
        public void SetData(UIItem_Data data)
        {
            itemNameText.text = data.itemData.displayName;
            countText.text = "X" + data.itemData.count;
            pointerImage.gameObject.SetActive(data.isSelected);
        }

    }

    public class UIItem_Data
    {
        public ItemData itemData;
        public bool isSelected;

        public UIItem_Data(ItemData itemData, bool isSelected)
        {
            this.itemData = itemData;
            this.isSelected = isSelected;
        }
    }
}