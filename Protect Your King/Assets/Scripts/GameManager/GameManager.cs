using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemyCount; //enemies in level
    public int levelCount; //next level #
    public GameObject UI; //Assigns canvas UI

    public void Start()
    {
        UI.SetActive(false);
    }
    public void enemyDefeated()
    {
        print("a");
        enemyCount--;
        if(enemyCount <= 0)
        {
            print("Game Over, Victory");
            UI.SetActive(true);
        }
    }
    public void nextLevel()
    {
        SceneManager.LoadScene("Level_" + levelCount);
    }

    public void returnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
