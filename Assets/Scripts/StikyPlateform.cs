using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StikyPlateform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Hero")
        {
            other.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Hero")
        {
            other.gameObject.transform.SetParent(null);
        }
    }
}
