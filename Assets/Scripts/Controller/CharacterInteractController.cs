using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour
{
    CharacterController2D characterController2D;
    Rigidbody2D rigidbody2D;
    [SerializeField] float offSetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;

    [SerializeField] HightlightController highlightController;

 
    private void Awake()
    {
        characterController2D = GetComponent<CharacterController2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    
    }

    private void Update()
    {
        CheckHighlight();
        if(Input.GetMouseButtonDown(1))
        {
            Interact();
            
        }
    }

    private void CheckHighlight()
    {
        Vector2 position = rigidbody2D.position + characterController2D.lastMotionVector * offSetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach(Collider2D c in colliders)
        {
            Interactable inter = c.GetComponent<Interactable>();
            if(inter != null)
            {
                highlightController.Highlight(inter.gameObject);
                break;
            }
            highlightController.Hide();
        }



    }

    private void Interact()
    {
        Vector2 position = rigidbody2D.position + characterController2D.lastMotionVector * offSetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach(Collider2D c in colliders)
        {
            Interactable inter = c.GetComponent<Interactable>();
            if(inter != null)
            {
                inter.Interact();
                break;
            }
        }
        
    }
}
