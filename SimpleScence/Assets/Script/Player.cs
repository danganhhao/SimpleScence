using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 50f, maxspeed = 10, jumpPow = 220f;
    public Rigidbody2D r2;
    public bool grounded = true, left = true, isRunning = false;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Grounded", grounded);
        animator.SetFloat("Speed", Mathf.Abs(r2.velocity.x));
        animator.SetBool("IsRunning", isRunning);

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (grounded)
        //    {
        //        r2.AddForce(Vector2.up * jumpPow);
        //    }
        //}
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)
           || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            isRunning = true;
        }
        if (Mathf.Abs(r2.velocity.x) < 0.001)
        {
            isRunning = false;
        }


    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        r2.AddForce((Vector2.right) * speed * h);
        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.position.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.position.y);

        if (h>0 && left)
        {
            Flip();
        }
        if (h < 0 && !left)
        {
            Flip();
        }
    }

    private void Flip()
    {
        left = !left;
        Vector3 scale;
        scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
