using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceNodeType
{
    Undefined,
    Tree,
    Ore
}

[CreateAssetMenu (menuName  = "Data/Tool action/Gather Resource Node")]
public class GatherResourceNode : ToolAction
{
    [SerializeField] float sizeOfInteractableArea = 1f;
    [SerializeField] List<ResourceNodeType> canHitNodesOfType;
    public override bool OnApply(Vector2 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach(Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if(hit != null)
            {
                if(hit.CanBeHit(canHitNodesOfType) == true)
                {
                    hit.Hit();
                    return true;
                }
                
            }
        }

        return false;
    }
}



