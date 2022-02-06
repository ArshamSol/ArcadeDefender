using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void PlayScene()
    {
        SceneManager.LoadScene("MainScene");    
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("GameMenu");
    }


}
