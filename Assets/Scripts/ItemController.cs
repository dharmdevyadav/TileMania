using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ItemController : MonoBehaviour
{
    [SerializeField] int PerCherryPoint = 1;
    
    [SerializeField] AudioSource CollectorEffect;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cherry")
        {
            FindObjectOfType<GameController>().AddToPoint(PerCherryPoint);
            CollectorEffect.Play();
            Destroy(other.gameObject);
            
            
        }
    }
}
