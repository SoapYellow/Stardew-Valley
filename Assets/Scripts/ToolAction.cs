using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ToolAction : ScriptableObject
{
   public virtual bool OnApply(Vector2 worldPoint)
   {
    Debug.LogWarning("OnApplyy is not implemneted");
    return true;
   }

   public virtual bool OnApplyToTileMap(Vector3Int gridPosition, TileMapReaderController tileMapReaderController)
   {
      Debug.LogWarning("OnApplyToTileMap is not implemented");
      return true;
   }
}
