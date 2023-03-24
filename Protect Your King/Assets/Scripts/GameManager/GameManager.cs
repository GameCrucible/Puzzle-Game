using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int enemyCount; //enemies in level
    public GameObject winUI; //Assigns canvas UI for victory screen
    public GameObject loseUI; //Assigns canvas UI for lose screen
    private bool gameOver = false; //prevents win and lose from appearing at the same time
    public bool isBossAlive; //Final Level check

    public void Start()
    {
        winUI.SetActive(false);
        loseUI.SetActive(false);
    }
    public void enemyDefeated()
    { //Opens victory when all enemies are defeated
        enemyCount--;
        if(enemyCount < 1 && isBossAlive == false)
        {
            if (gameOver)
            {

            }
            else
            {
                gameOver = true;
                winUI.SetActive(true);
            }
            
        }
    }

    public void lose()
    {
        if (gameOver)
        {

        }
        else
        {
            gameOver = true;
            loseUI.SetActive(true);
        }
        
    }

    public void bossDefeated()
    {
        isBossAlive = false;
        enemyCount++;
        enemyDefeated();
    }

    public void nextLevel() //swaps level
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void returnMenu() //returns to menu
    {
        SceneManager.LoadScene("Menu");
    }

    public void restart() //resets level
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
