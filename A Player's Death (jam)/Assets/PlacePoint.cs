using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePoint : MonoBehaviour
{
    BoxCollider2D coll;
    SpriteRenderer sprite;

    

    Color newColor;
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

        
    }

    
    void Update()
    {
        if (isInsideGround())
        {
            sprite.color = new Color(255, 0, 0);
            

        }
        else
        {
            sprite.color = new Color(255, 255, 255);
            
        }
    }

    bool isInsideGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size / 1.5f, 0f, Vector2.up, 1, LayerMask.GetMask("platform"));
    }
}
