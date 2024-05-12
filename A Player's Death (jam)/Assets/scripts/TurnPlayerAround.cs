using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPlayerAround : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerEnemy>())
        {
            PlayerEnemy player = collision.GetComponent<PlayerEnemy>();

            player.speed *= -1;
        }
    }
}
