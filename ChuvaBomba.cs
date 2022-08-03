using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuvaBomba : MonoBehaviour
{
    public GameObject Minion;
    public GameObject LocalSaida;
    public float tempo = 0;
    private bool podecriar = true;
    private Gerenciador GJ;
    public float tempo2 = 4;
    public Morte Morte;
    //public Animator Animador;

    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
    }


    void Update()
    {

        if (GJ.EstadoDoJogo() == true)
        {
            if (podecriar == true)
            {
                podecriar = false;
                Instantiate(Minion, LocalSaida.transform.position, Quaternion.identity);


            }

        }

        if (podecriar == false)
        {
            tempo2 += Time.deltaTime;
            if (tempo2 > 4f)
            {
                tempo2 = 0;
                podecriar = true;

            }
        }

       
    }

   
}
