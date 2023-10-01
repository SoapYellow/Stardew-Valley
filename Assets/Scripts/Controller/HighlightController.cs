using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HightlightController : MonoBehaviour
{
   [SerializeField] GameObject highlighter;
   GameObject currentTarget;

   public void Highlight(GameObject target)
   {
   
    currentTarget = target;
    Vector3 position = target.transform.position;
 
    Highlight(position);
   }

   public void Highlight(Vector3 position)
   {
    highlighter.SetActive(true);
    highlighter.transform.position = position;
   }

   public void Hide()
   {
    currentTarget = null;
    highlighter.SetActive(false);
   } 
}
