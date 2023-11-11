using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    [SerializeField] AudioSource DeathEffect;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb= GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "spikes")
        {
            
            DeathEffect.Play();
            animator.SetTrigger("death");
            //FindObjectOfType<ScenePersist>().ResetScenePersist();
            FindObjectOfType<GameController>().ProcessPlayerDeath();
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene("EndScene",LoadSceneMode.Single);
    }
}
