using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class JumpSuppressor : MonoBehaviour
{
    PlayerEnemy player;
    SpriteRenderer spriteRenderer;

    public int SuppressionIndex;

    private void Start()
    {
        player = FindObjectOfType<PlayerEnemy>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        player.JumpDistances[SuppressionIndex].DoJump = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        player.JumpDistances[SuppressionIndex].DoJump = true;
    }

}
