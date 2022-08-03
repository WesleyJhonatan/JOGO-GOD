using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gira : MonoBehaviour
{
    public float Girando = 1;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            transform.Rotate(Vector3.up * Girando * Time.deltaTime);
        }
    }
}
