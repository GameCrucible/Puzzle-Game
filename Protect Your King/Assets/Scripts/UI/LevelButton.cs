using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public void OpenScene()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void howTo()
    {

    }

    public void Exit()
    {
        Application.Quit();
    }
}
