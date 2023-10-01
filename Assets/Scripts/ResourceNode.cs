using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ResourceNode : ToolHit
{
   private int logDropCount = 5;
   private float spread = 0.9f;
   [SerializeField] GameObject droppedItem;
   [SerializeField] Item item;
   [SerializeField] int itemCountInOneDrop = 1;
   [SerializeField] int dropCount = 5;
   [SerializeField] ResourceNodeType nodeType;

   UnityEngine.Object myPrefabs;
   private void Start()
   {
      myPrefabs = Resources.Load("Prefabs/Log"); 

   }
   public override void Hit()
   {
      
      while(logDropCount > 0)
      {
         logDropCount--;
         Vector3 position = transform.position;
         position.x += UnityEngine.Random.value * spread - spread / 2;
         position.y -= UnityEngine.Random.value * spread - spread / 2;
         ItemSpawnManager.instance.SpawnItem(position, item, itemCountInOneDrop);
      }

      Destroy(gameObject);
   }

   public override bool CanBeHit(List<ResourceNodeType> canBeHit)
   {
      return canBeHit.Contains(nodeType);
   }
}
