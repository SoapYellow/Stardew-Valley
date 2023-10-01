using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] public GameObject player;

    public ItemContainer inventoryContainer;
    public ItemDragAndDropController dragAndDropController;


    public void Awake()
    {
        instance = this;
    }

   
}
