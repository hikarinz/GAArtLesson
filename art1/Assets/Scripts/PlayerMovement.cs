using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float speed = 1;
    public float jumpForce = 1;

    //public float groundCheckDistance = 0.1f;

    SpriteRenderer sprite = null;
    Rigidbody2D rb = null;

    bool inAir = false;
    

    float scaleX = 1;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        

        sprite = GetComponentInChildren<SpriteRenderer>();
        scaleX = transform.localScale.x;
    }


    void Update()
    {
        rb.velocity = Vector2.right * Input.GetAxis("Horizontal") * speed + Vector2.up * rb.velocity.y;
       

        if(Input.GetAxis("Horizontal") != 0) {
            int direction = 1;
            //animator.ResetTrigger("Jump");
            animator.SetTrigger("Run");
            if (Input.GetAxis("Horizontal") < 0) {
            direction = -1;
            }
            transform.localScale = new Vector3(scaleX * direction, transform.localScale.y, transform.localScale.z);

        } else
        {
            animator.ResetTrigger("Run");
        }

        // RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        inAir = hit.collider == null;


        if (!inAir && Input.GetButtonDown("Jump"))
        {

            //animator.ResetTrigger("Run");
            animator.SetTrigger("Jump");
            transform.position += Vector3.up * 0.2f;
            rb.AddForce(Vector2.up * jumpForce);


        }
        else
        {
            animator.ResetTrigger("Jump");
        }


    }
}
