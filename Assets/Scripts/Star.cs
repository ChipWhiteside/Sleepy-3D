using Silence;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private Material mat;

    void Start()
    {
        // Log 10:
        // 1 = 0
        // 10 = 1
        // 100 = 2
        // 1000 = 3
        float alpha = 1 - (Mathf.Log(transform.position.z, 100) / Mathf.Log(GameManager.instance.zIterationsBack, 100)); 

        mat = GetComponent<Material>();
        if (mat != null)
        {
            mat.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), alpha);
        }
    }
}
