using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
   
    Transform playerTransform;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickUpDistance = 0.5f;
    [SerializeField] float ttl = 10f;
    [SerializeField] float minimumDistance = 0.1f;
    
    [SerializeField] public Item item;
    public int count = 1;

    private void Awake()
    {
        playerTransform = GameManager.instance.player.transform;
        
    }

    public void Set(Item item, int count)
    {
        this.item = item;
        this.count = count;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.icon;
    }
  
    private void Update()
    {
        ttl -= Time.deltaTime;
        if(ttl < 0) {Destroy(gameObject);}
        
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if(pickUpDistance < distance)
        {
            return;
        }

        transform.position = Vector3.MoveTowards
            (transform.position, playerTransform.position, speed * Time.deltaTime);

        if(distance < minimumDistance)
        {
            if(GameManager.instance.inventoryContainer != null)
            {
                GameManager.instance.inventoryContainer.Add(item, count);
            } else {
                Debug.LogWarning("No inventory container attached to the game manager");
            }
            Destroy(gameObject);
        }
    }
    
}
