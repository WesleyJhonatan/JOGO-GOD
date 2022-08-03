using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroi : MonoBehaviour
{
    public GameObject Minion;
    public GameObject LocalSaida;
    void Start()
    {

    }

    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision colidiu)
    {
        if (colidiu.gameObject.tag == "Chao")
        {
            Instantiate(Minion, LocalSaida.transform.position, Quaternion.identity);
            Destroy(this.gameObject, 1);
           
        }

    }
}
