using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float Speed = 10f;

    /*void Start()
    {
        
    }*/

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0,360*Speed*Time.deltaTime);
    }
}
