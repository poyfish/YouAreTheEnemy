using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayerCollision : MonoBehaviour
{
    void Awake()
    {
        Physics2D.IgnoreCollision(GameObject.FindObjectOfType<PlayerEnemy>().GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
