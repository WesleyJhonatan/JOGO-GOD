using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movimento_Inimigo : MonoBehaviour
{
    private NavMeshAgent Agente;
    private GameObject Heroi;
    public bool atacando = false;
    public float tempo = 0;
    public Animator Animador;
    public bool podeAndar = true;
    public float tempoB = 0;
    float DistanciaHeroi;

    private Gerenciador GJ;

    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
        Animador = GetComponent<Animator>();
        Agente = GetComponent<NavMeshAgent>();
        Heroi = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            if (podeAndar == true)
            {
                DistanciaHeroi = Vector3.Distance(transform.position, Heroi.transform.position);
                if (DistanciaHeroi < 10 && DistanciaHeroi > 1)
                {
                    Agente.speed = 2;
                    MoverInimigo();
                    Animador.SetBool("Andar", true);
                    Animador.SetBool("Bater", false);
                }

            }


            if (DistanciaHeroi < 30 && DistanciaHeroi > 11)
            {
                //Debug.Log("fora");
                Agente.speed = 0;
                Animador.SetBool("Bater", false);
                Animador.SetBool("Andar", false);
            }
        }
        
    }


    private void MoverInimigo()
    {
        Agente.destination = Heroi.transform.position;
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            podeAndar = false;
            Animador.SetBool("Bater", true);
            Animador.SetBool("Andar", false);
        }

    }

    void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            podeAndar = true;
            Animador.SetBool("Bater", false);
        }
    }
}