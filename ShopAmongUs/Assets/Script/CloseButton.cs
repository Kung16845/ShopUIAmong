using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopUIAmongUs
{
    public class CloseButton : MonoBehaviour
    {
    // Start is called before the first frame update
    [SerializeField] GameObject closeButton;
    [SerializeField] ItemList itemList;
    void Start()
    {
        // Initially, hide the close button
        closeButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if data is loaded (you may need a reference to your ItemList script)
        if (ItemListIsLoaded())
        {
            // If data is loaded, show the close button
            closeButton.SetActive(true);
        }
    }
    bool ItemListIsLoaded()
    {
    if (itemList != null)
    {
        return true;
    }
    else
    {
        return false;
    }
}
}
}
