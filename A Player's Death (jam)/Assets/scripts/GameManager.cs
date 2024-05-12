using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> WinUIElements;
    public PlayerEnemy player;

    public List<GameObject> LooseUIElements;

    bool hasWon = false;

    bool hasLost = false;

    IEnumerator YouWin()
    {
        yield return new WaitForSeconds(1.5f);

        foreach (GameObject uiElement in WinUIElements)
        {
            uiElement.SetActive(true);
        }

        hasWon = true;
    }

    IEnumerator YouLoose()
    {
        yield return new WaitForSeconds(1.5f);

        foreach (GameObject uiElement in LooseUIElements)
        {
            uiElement.SetActive(true);
        }

        hasLost = true;
    }

    void Start()
    {
        foreach (GameObject uiElement in WinUIElements)
        {
            uiElement.SetActive(false);
        }

        foreach (GameObject uiElement in LooseUIElements)
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

        if (player.didReachGoal)
        {
            StartCoroutine(YouLoose());
        }
    }
}
