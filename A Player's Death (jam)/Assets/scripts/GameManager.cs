using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> WinUIElements;
    public PlayerEnemy player;

    bool hasWon = false;

    IEnumerator YouWin()
    {
        yield return new WaitForSeconds(1.5f);

        foreach (GameObject uiElement in WinUIElements)
        {
            uiElement.SetActive(true);
        }

        hasWon = true;
    }

    void Start()
    {
        foreach (GameObject uiElement in WinUIElements)
        {
            uiElement.SetActive(false);
        }
    }

    void Update()
    {
        if (player.isDead && !hasWon)
        {
            StartCoroutine(YouWin());
        }
    }
}
