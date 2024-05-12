using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPlayerAround : MonoBehaviour
{
    PlayerEnemy player;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        player = FindObjectOfType<PlayerEnemy>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerEnemy>())
        {
            print("hit");

            player.movementSpeed *= -1;

            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
}
