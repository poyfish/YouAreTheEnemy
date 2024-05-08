using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D coll;
    Animator anim;

    public float jumpForce;
    public float speed;

    float movementSpeed;

    public float boxCastDistance;

    public float deathBoxCastDistance;

    public bool isDead;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

        Go();
    }


    void Update()
    {
        if (!isDead)
        {
            //see if the box cast touches wall
            bool foundWall = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size / 2, 0f, Vector2.right, boxCastDistance, LayerMask.GetMask("platform"));


            bool foundObstacle = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size / 2, 0f, Vector2.right, deathBoxCastDistance, LayerMask.GetMask("death"));



            //ground check
            if (foundWall && isGrounded() || foundObstacle && isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y);

            Animations();
        }
    }

    void Animations()
    {
        if (rb.velocity.y > 0 && !isGrounded())
        {
            anim.CrossFade("player_jumping", 0, 0);
        }


        //falling animation dosn't work fix that!
        else if (rb.velocity.y > 0 && !isGrounded())
        {
            anim.CrossFade("player_falling", 0, 0);
        }

        else if(isGrounded())
        {
            anim.CrossFade("player_running", 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("death"))
        {
            isDead = true;

            

            anim.CrossFade("player_death", 0, 0);
        }
    }

    private void Go()
    {
        movementSpeed = speed;
    }

    private void Stop()
    {
        movementSpeed = 0f;
    }

    bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size / 2, 0f, Vector2.down, 1, LayerMask.GetMask("platform"));
    }
}
