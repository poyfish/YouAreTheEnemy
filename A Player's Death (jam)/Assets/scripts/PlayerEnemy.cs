using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static PlayerEnemy;

public class PlayerEnemy : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D coll;
    Animator anim;

    public float speed;

    float movementSpeed;

    public bool isDead;


    public int health;

    public bool didReachGoal;


    [System.Serializable]
    public struct JumpDistance
    {
        public LayerMask Layer;

        public float Distance;

        public float JumpForce;
    }

    public JumpDistance[] JumpDistances;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

        Go();
    }


    void Update()
    {
        if (isDead) return;

        foreach (JumpDistance jumpDistance in JumpDistances)
        {
            RaycastHit2D ShouldJump = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size / 3, 0f, Vector2.right, jumpDistance.Distance, jumpDistance.Layer);

            if (ShouldJump && isGrounded())
            {

                transform.position += new Vector3(0, 0.6f);

                rb.velocity = new Vector2(rb.velocity.x, jumpDistance.JumpForce);

                Debug.Log($"{ShouldJump.collider.gameObject.name} at {Time.time}", ShouldJump.collider.gameObject);
            }
        }



        rb.velocity = new Vector2(movementSpeed, rb.velocity.y);


        Animations();
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
            health--;

            if (health <= 0)
            {
                isDead = true;

                foreach (Collider2D collider in FindObjectsOfType<Collider2D>().Where(G => G.gameObject.CompareTag("death")))
                {
                    Physics2D.IgnoreCollision(coll, collider);
                }

                anim.CrossFade("player_death", 0, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "goal")
        {
            didReachGoal = true;
        }

        if (other.tag == "death")
        {
            health--;

            if (health <= 0)
            {
                isDead = true;

                foreach (Collider2D collider in FindObjectsOfType<Collider2D>().Where(G => G.gameObject.CompareTag("death")))
                {
                    Physics2D.IgnoreCollision(coll, collider);
                }

                anim.CrossFade("player_death", 0, 0);
            }
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
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size / 2, 0f, Vector2.down, .5f, LayerMask.GetMask("platform"));
    }
}
