using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ShopUIAmongUs.Json
{
    public class UIShopJson : MonoBehaviour
    {
        [SerializeField] TMP_Text NameText;
        [SerializeField] Image photoImage;
        [SerializeField] TMP_Text DescriptionText;
        [SerializeField] TMP_Text priceText;
        [SerializeField] TMP_Text categoryTypeText;

        public void SetPhoto(Sprite photo)
        {
            photoImage.sprite = photo;
        }
        
        public void SetDataJson(ItemDataJson data)
        {
            NameText.text = data.displayName.ToString();
            DescriptionText.text = data.displayDescription;
            priceText.text = data.price.ToString();
            categoryTypeText.text = ((CategoryType)data.type).ToString();
            
        }
    }
    
}
