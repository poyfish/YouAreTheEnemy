using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Animator anim;
    BoxCollider2D coll;
    Rigidbody2D rb;

    public bool doesUseWalkingAnimation;


    public bool doesHaveRigidBody;

    public string startingAnimationName;
    public string PlacedAnimationName;

    public string walkingAnimationName;

    public bool isReady;


    public bool isInsidePlayer;

    bool x = false;

    public Action OnReady;
    void Start()
    {
        

        if (doesHaveRigidBody)
        {
            rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;
        }

        anim = GetComponent<Animator>();

        anim.CrossFade(PlacedAnimationName, 0, 0);

        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (isReady && doesHaveRigidBody)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            coll.enabled = true;
        }

        if (isReady && doesUseWalkingAnimation)
        {
            anim.CrossFade(walkingAnimationName, 0, 0);
        }

        if (isReady && !isInsidePlayer)
        {
            transform.gameObject.tag = "death";
        }

        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            
            if (x == false)
            {
                print("test");
                x = true;
                transform.gameObject.tag = "Untagged";
                isInsidePlayer = true;
            }
        }
    }

    void StartSpike()
    {
        anim.CrossFade(startingAnimationName, 0, 0);
    }

    void Ready()
    {
        isReady = true;

        OnReady.Invoke();
    }
}
