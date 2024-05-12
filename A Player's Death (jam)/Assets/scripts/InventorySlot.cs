using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public GameObject obstacle;

    public GameObject ObstaclePlaceHolder;

    public Sprite NonSelectedSprite;

    public Sprite SelectedSprite;

    private SpriteRenderer sprite;

    private ObstaclePlacer placer;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();

        placer = GameObject.FindObjectOfType<ObstaclePlacer>();

        print(placer.gameObject.name);
    }

 
    public void OnSelcted()
    {

        placer.obstacle = obstacle;

        placer.ObstaclePlaceHolder = ObstaclePlaceHolder;

        sprite.sprite = SelectedSprite;
    }

    public void OnDeselected()
    {
        sprite.sprite = NonSelectedSprite;
    }
}
