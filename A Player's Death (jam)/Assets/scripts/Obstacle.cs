using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Animator anim;

    public string startingAnimationName;
    public string PlacedAnimationName;

    public bool isReady;
    void Start()
    {
        anim = GetComponent<Animator>();

        anim.CrossFade(PlacedAnimationName, 0, 0);
    }

    void StartSpike()
    {
        anim.CrossFade(startingAnimationName, 0, 0);
    }

    void Ready()
    {
        isReady = true;
    }
}
