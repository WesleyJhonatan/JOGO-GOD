using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mensagem : MonoBehaviour
{
    [Range(0.1f, 10.0f)] public float distancia = 3;
    private GameObject Jogador;
    public GameObject Q;
    void Start()
    {
        Jogador = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if(Vector3.Distance (transform.position, Jogador.transform.position) < distancia)
        {
            Q.SetActive(true);
        }

        else
        {
            Q.SetActive(false);
        }

        
    }
}
