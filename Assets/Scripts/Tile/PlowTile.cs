using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu (menuName  = "Data/ToolAction/Plow")]
public class PlowTile : ToolAction
{
    [SerializeField]List<TileBase> canPlow;

    public override bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReaderController tileMapReaderController)
    {
        TileBase tileToPlow = tileMapReaderController.GetTileBase(gridPosition);
        if(canPlow.Contains(tileToPlow) == false)
        {
            return false;
        }
        tileMapReaderController.cropsManager.Plow(gridPosition);
        return true;
    }
    
}
