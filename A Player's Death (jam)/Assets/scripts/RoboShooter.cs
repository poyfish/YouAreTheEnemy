using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboShooter : MonoBehaviour
{
    public Obstacle obs;

    public BoxCollider2D BulletColl;

    Animator anim;

    public GameObject bulletPrefab;
    public float yOffset = 1f;
    public float shootForce = 10f;

    private void Start()
    {
        anim = GetComponent<Animator>();


    }

    void Update()
    {
        if (obs.isReady)
        {
            anim.CrossFade("robo_shooter_shooting", 0, 0);
        }
    }
    void Shoot()
    {
        Vector3 shootPoint = transform.position + new Vector3(0, yOffset, 0);
        GameObject bullet = Instantiate(bulletPrefab, shootPoint, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(Vector2.left * shootForce, ForceMode2D.Impulse);
        }
    }
}
