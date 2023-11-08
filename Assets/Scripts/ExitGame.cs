using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    /*private void Start()
    {
        Invoke("EndGame", 2f);
        Invoke("RestartGame", 3f);
    }*/
    public void EndGame()
    {
        SceneManager.LoadScene("StartScene", LoadSceneMode.Single);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level1",LoadSceneMode.Single);
    }
}
