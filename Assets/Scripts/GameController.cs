using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] int Cherries = 0;
    [SerializeField] int PlayerLives = 3;
    [SerializeField] TextMeshProUGUI CountText;
    [SerializeField] TextMeshProUGUI LivesText;

    public void Awake()
    {

        int numGameSession = FindObjectsOfType<GameController>().Length;
        if (numGameSession > 1)
        {
            Destroy(gameObject);

        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        CountText.text = "Cherries:" + Cherries.ToString();
        LivesText.text = "Lives:" + PlayerLives.ToString();
    }

    public void ProcessPlayerDeath()
    {
        if (PlayerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void TakeLife()
    {
        PlayerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        LivesText.text = "Lives:" + PlayerLives.ToString();
    }

    public void AddToPoint(int pointToAdd)
    {
        Cherries += pointToAdd;
        CountText.text = "Cherries:" + Cherries.ToString();
    }

    private void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(3);
        Destroy(gameObject);
    }
}
