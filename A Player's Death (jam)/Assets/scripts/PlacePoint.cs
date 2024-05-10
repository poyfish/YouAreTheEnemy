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
                sprite.color = new Color(255, 0, 0, sprite.color.a);
            }
            else
            {
                sprite.color = new Color(255, 255, 255, sprite.color.a);
            }
    }

    public bool isInsideGround()
    {
        try
        {
            return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size / 1.7f, 0f, Vector2.up, 1, LayerMask.GetMask("platform"));
        }
        catch
        {
            return false;
        }
    }
}
