using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSuppressor : MonoBehaviour
{
    PlayerEnemy player;
    SpriteRenderer spriteRenderer;

    public LayerMask MaskToSuppress;

    private void Start()
    {
        player = FindObjectOfType<PlayerEnemy>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    
}
