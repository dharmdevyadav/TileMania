using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private int Cherries = 0;
    [SerializeField]private TextMeshProUGUI countText;
    [SerializeField] AudioSource CollectorEffect;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cherry")
        {
            CollectorEffect.Play();
            Destroy(other.gameObject);
            Cherries++;
            countText.text ="Cherries: " + Cherries;
        }
    }
}
