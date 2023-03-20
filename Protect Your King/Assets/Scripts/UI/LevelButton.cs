using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    void OnClick()
    {
        print("A");
    }

    public void OpenScene()
    {
        SceneManager.LoadScene("Scene_1");
    }
}
