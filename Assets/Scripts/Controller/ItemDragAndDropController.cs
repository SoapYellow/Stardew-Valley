using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ItemDragAndDropController : MonoBehaviour
{
    [SerializeField] ItemSlot itemSlot;
    [SerializeField] GameObject iconObject;
    RectTransform iconTransform;
    Image itemImage;

    private void Start()
    {
        itemSlot = new ItemSlot();
        iconTransform = iconObject.GetComponent<RectTransform>();
        itemImage = iconObject.GetComponent<Image>();
    }

    private void Update()
    {
       if(iconObject.activeInHierarchy == true)
       {
            iconTransform.position = Input.mousePosition;
            if(Input.GetMouseButtonUp(0))
            {
                if(EventSystem.current.IsPointerOverGameObject() == false)
                {
                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    worldPosition.z = 0.5f;
                    ItemSpawnManager.instance.SpawnItem(worldPosition, itemSlot.item, itemSlot.count);

                    itemSlot.Clear();
                    iconObject.SetActive(false);
                    
                    
                }
            }
       }
    }

    internal void OnClick(ItemSlot itemSlot)
    {
        if(this.itemSlot.item == null)
        {
            this.itemSlot.Copy(itemSlot);
            itemSlot.Clear();
            
        } else { 
            Item item = itemSlot.item;
            int count = itemSlot.count;
            itemSlot.Copy(this.itemSlot);
            this.itemSlot.Set(item, count);   
        }
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if(itemSlot.item == null)
        {
            iconObject.SetActive(false);
        } else {
            iconObject.SetActive(true);
            itemImage.sprite = itemSlot.item.icon;
        }
    }


}
