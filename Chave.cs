using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chave : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider colidiu)
    {
        if (colidiu.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }

    }
}
