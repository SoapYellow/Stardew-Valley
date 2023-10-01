using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootContainerInteractable : Interactable
{
    [SerializeField] GameObject colsedChest;
    [SerializeField] GameObject openedChest;
    [SerializeField] bool opened = false;

    public override void Interact()
    {
        colsedChest.SetActive(opened);
        openedChest.SetActive(!opened);
        opened = !opened; 
    }
}
