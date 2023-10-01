using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Animator anim;
    [SerializeField] private float speed = 2f;
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    bool moving = false;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    


    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        motionVector = new Vector2(horizontal, vertical);
        anim.SetFloat("horizontal", horizontal);
        anim.SetFloat("vertical", vertical);

        moving = horizontal != 0 || vertical != 0;
        anim.SetBool("moving", moving);

        if(moving)
        {
            lastMotionVector = new Vector2(horizontal, vertical).normalized;
            anim.SetFloat("lastHorizontal", horizontal);
            anim.SetFloat("lastVertical", vertical);
        }
        

    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigidbody2d.velocity = motionVector * speed;
    }
}
