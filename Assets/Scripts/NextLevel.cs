using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextLevel : MonoBehaviour
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

            Invoke("LoadNextLevel", 2f);
            //Invoke("CompleteLevel", 2f);
        }


    }
    private void LoadNextLevel()
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }

}
