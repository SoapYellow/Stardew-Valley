using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ToolCharacterController : MonoBehaviour
{
    CharacterController2D characterController2D;
    Rigidbody2D rigidbody2D;
    ToolbarController toolbarController;
    [SerializeField] float offSetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;

    [SerializeField] MarkerManager markerManager;
 
    [SerializeField] TileMapReaderController tileMapReaderController;
    [SerializeField] float maxDistance = 1.5f;
   
   
    Vector3Int selectedTilePosition;
    bool selectable;

    private void Awake()
    {
        characterController2D = GetComponent<CharacterController2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        toolbarController = GetComponent<ToolbarController>();
    }

    private void Update()
    {
        SelectTile();
        CanSelectCheck();
        Marker();
        if(Input.GetMouseButtonDown(0))
        {
            if(UseToolWorld() == true)
            {
                return;
            }
            UseToolGrid();
        }
    }

    private void SelectTile()
    {
        selectedTilePosition = tileMapReaderController.GetGridPosition(Input.mousePosition, true);
    }

    void CanSelectCheck()
    {
        Vector2 characterPosition = transform.position;
        Vector2 cameraPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectable = Vector2.Distance(characterPosition, cameraPosition) < maxDistance;
        markerManager.Show(selectable);
    }
    private void Marker()
    {
       markerManager.markedCellPosition = selectedTilePosition;

    }

    private bool UseToolWorld()
    {
        Vector2 position = rigidbody2D.position + characterController2D.lastMotionVector * offSetDistance;
        
        Item item = toolbarController.GetItem;
        if (item == null) {return false;}
        if(item.onAction == null) {return false;}

        bool complete = item.onAction.OnApply(position);        
        return complete;
        
    }

    private void UseToolGrid()
    {
        if(selectable == true)
        {
            Item item = toolbarController.GetItem;
            if(item == null) {return;}
            if(item.onTileMapAction == null) {return;}

            bool complete = item.onTileMapAction.OnApplyToTileMap(selectedTilePosition, tileMapReaderController);
        }
    }
}
