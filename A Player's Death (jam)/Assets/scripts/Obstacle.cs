using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Animator anim;
    BoxCollider2D coll;

    //public PlayerEnemy player;

    public string startingAnimationName;
    public string PlacedAnimationName;

    public bool isReady;

    public Action OnReady;
    void Start()
    {
        anim = GetComponent<Animator>();

        anim.CrossFade(PlacedAnimationName, 0, 0);

        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        /*
        if(player.isDead == true)
        {
            coll.enabled = false;
        }
        */
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
