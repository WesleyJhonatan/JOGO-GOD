using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaVida : MonoBehaviour
{
    private Animator Animacao;
    public GameObject Efeito;
    public GameObject BTQ;
    private bool ComecaTempo = false;
    private float tempo = 0;
    private bool Comeca = false;
    void Start()
    {
        Animacao = GetComponent<Animator>();
    }

    void Update()
    {
        if (Comeca == true)
        {
            tempo += Time.deltaTime;
            if (tempo >= 10)
            {
                GetComponent<Mensagem>().enabled = true;
                Comeca = false;
                ComecaTempo = false;
                tempo = 0;
            }
        }
    }


    public void OnTriggerStay(Collider colidiu)
    {
        if (colidiu.gameObject.tag == "Player")
        {

            if (ComecaTempo == true)
            {
                colidiu.gameObject.GetComponent<Personagem>().AumentaVida();
                GetComponent<Mensagem>().enabled = false;
                BTQ.SetActive(false);
                Efeito.SetActive(true);
                Animacao.SetBool("Aberto", true);
                ComecaTempo = false;
                Comeca = true;
            }
        }


    }

    public void ParaAbre()
    {
        Efeito.SetActive(false);
        Animacao.SetBool("Aberto", false);
    }

    public void LigaTri()
    {
        if (Comeca == false)
        {
            ComecaTempo = true;
        }

    }


}