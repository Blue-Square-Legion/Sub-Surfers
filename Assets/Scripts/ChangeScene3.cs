using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene3 : MonoBehaviour
{
    public void OnExit()
    {
        Application.Quit();
    }

    public void OnRetry()
    {
        SceneManager.LoadScene("ThirdPersonMovement");
    }

    public void OnGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void OnFinish()
    {
        SceneManager.LoadScene("Finish");
    }
}