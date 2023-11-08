using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPageLoad : MonoBehaviour
{
    private AudioSource FinishEffect;
    private bool isFinish = false;
    private void Start()
    {
        FinishEffect = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Hero" && !isFinish)
        {
            FinishEffect.Play();
            isFinish = true;
            Invoke("GameOver", 2f);
            
        }


    }
    private void GameOver()
    {
        SceneManager.LoadScene("EndScene", LoadSceneMode.Single);
    }
}

