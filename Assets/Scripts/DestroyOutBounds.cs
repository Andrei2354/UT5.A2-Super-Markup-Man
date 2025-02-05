using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBounds : MonoBehaviour
{
    private float topBound = 15;
    void Start()
    {

    }
    void Update()
    {
        if (transform.position.y < topBound)
        {
            Destroy(gameObject);
        }
    }
}
