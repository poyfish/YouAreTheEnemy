using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PlayerEnemy player;

    int currentInventorySlot = 0;


    public List<GameObject> inventorySlots;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (player.isDead)
        {

        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            if(currentInventorySlot < inventorySlots.Count)
            {
                currentInventorySlot++;
            }
        }
    }
   private void CompleteLevel()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }
    
}
