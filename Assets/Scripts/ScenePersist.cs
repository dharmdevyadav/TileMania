using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    public void Awake()
    {
        int numSceneLoad = FindObjectsOfType<ScenePersist>().Length;
        if (numSceneLoad > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }
    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }

}
