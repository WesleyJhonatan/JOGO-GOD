using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoCastelo : MonoBehaviour
{
    public GameObject Minion;
    public GameObject LocalSaida;
    private GameObject Heroi;
    public float tempo = 0;
    private bool podecriar = true;
    private Gerenciador GJ;
    //public Animator Animador;

    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
        Heroi = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            float DistanciaHeroi = Vector3.Distance(transform.position, Heroi.transform.position);
            if (DistanciaHeroi < 10 && DistanciaHeroi > 2)
            {
                CriarMostro();
            }

            if (podecriar == false)
            {
                tempo += Time.deltaTime;
                if (tempo > 10)
                {
                    tempo = 0;
                    podecriar = true;
                }
            }
        }
           
       

    }

    public void CriarMostro()
    {
        if(podecriar == true)
        {
            Instantiate(Minion, LocalSaida.transform.position, Quaternion.identity);
            podecriar = false;
        }
        
    }
}
