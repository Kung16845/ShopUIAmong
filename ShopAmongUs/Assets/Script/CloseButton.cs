using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopUIAmongUs
{
    public class CloseButton : MonoBehaviour
    {
    // Start is called before the first frame update
    [SerializeField] GameObject closeButton;
    [SerializeField] InventoryPresenter itemList;
    [SerializeField] Animation_DOtween anima;
    bool isShopOpen=false;
        
        void Start()
    {
        anima.ExitTransition();
    }

    public void Clickshop()
    {
            if (isShopOpen) { anima.ExitTransition();  }
            else { anima.EnterTransition();
                itemList.setShopStart();
            }
            isShopOpen = !isShopOpen;
        }

 
}
}

