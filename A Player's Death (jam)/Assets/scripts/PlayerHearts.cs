using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHearts : MonoBehaviour
{
    SpriteRenderer spriteRend;

    public Sprite oneHeart;
    public Sprite twoHearts;
    public Sprite threeHearts;

    public PlayerEnemy player;

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (player.health == 1)
        {
            spriteRend.sprite = oneHeart;
        }

        if (player.health == 2)
        {
            spriteRend.sprite = twoHearts;
        }

        if (player.health == 3)
        {
            spriteRend.sprite = threeHearts;
        }

        if (player.health <= 0)
        {
            spriteRend.enabled = false;
        }
    }
}
