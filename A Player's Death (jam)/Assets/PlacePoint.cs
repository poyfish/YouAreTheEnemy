using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacePoint : MonoBehaviour
{
    BoxCollider2D coll;
    SpriteRenderer sprite;

    private Color originalColor;

    Color newColor;
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

        originalColor = sprite.color;
    }

    
    void Update()
    {
        if (isInsideGround())
        {
            sprite.color = Color.red;
            newColor.a = originalColor.a;

        }
        else
        {
            sprite.color = Color.white;
            newColor.a = originalColor.a;
        }
    }

    bool isInsideGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size / 1.5f, 0f, Vector2.up, 1, LayerMask.GetMask("platform"));
    }
}
