using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.EventSystems;

public class InventoryButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image icon;
    [SerializeField] Text text;
    [SerializeField] GameObject highlightGo;

    int myIndex;

    public void SetIndex(int index)
    {
        myIndex = index;
    }

    public void Set(ItemSlot itemSlot)
    {
        icon.sprite = itemSlot.item.icon;
        icon.gameObject.SetActive(true);
        if(itemSlot.item.stackable == true)
        {
            text.gameObject.SetActive(true);
            text.text = itemSlot.count.ToString();
        }
        
        
    }

    public void Clean()
    {
        icon.sprite = null;
        icon.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ItemPanel itemPanel = transform.parent.GetComponent<ItemPanel>();
        itemPanel.OnClick(myIndex);
    }

    public void Highlight(bool h)
    {
        highlightGo.gameObject.SetActive(h);
    }
    
}
