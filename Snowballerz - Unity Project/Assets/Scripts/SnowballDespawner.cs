using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballDespawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bruh");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Bruh");
    }
}
