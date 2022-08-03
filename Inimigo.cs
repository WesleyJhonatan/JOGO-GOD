using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int HP = 374;
    public int HPBarra = 0;
    public Animator Animacao;
    public Ataque_Inimigo MeuAtaque;
    public Ataque_Inimigo MeuAtaque2;

    private Gerenciador GJ;
    private bool parador = false;
    private float tempodor = 0;
    private bool TiraVidaP = false;
    private float tempoVidaP = 0;

    public RectTransform ImagemHP;
    public int recompensa2 = 0;


    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
        Animacao = GetComponent<Animator>();
    }

    void Update()
    {

        if (GJ.EstadoDoJogo() == true)
        {
            AnimaMorrer();

            ImagemHP.sizeDelta = new Vector2(HP, 43f);

            if (parador == true)
            {
                tempodor += Time.deltaTime;
                if (tempodor >= 0.6)
                {
                    Animacao.SetBool("Dano", false);
                }

            }

            if (TiraVidaP == true)
            {
                tempoVidaP += Time.deltaTime;
                if (tempoVidaP >= 0.8)
                {
                    MeuAtaque.possoAtacar = false;
                    MeuAtaque2.possoAtacar = false;
                    tempoVidaP = 0;
                    TiraVidaP = false;
                }


            }

        }



    }

    public void ComecaAtaque()
    {
        MeuAtaque.possoAtacar = true;
        MeuAtaque2.possoAtacar = true;
        TiraVidaP = true;
    }

    public void Dano()
    {
        if (HP > 0)
        {
            if (HP >= 1)
            {

                HP = HP - 5;
                parador = true;
                Animacao.SetBool("Dano", true);
                Animacao.SetBool("Morreu", false);
                Animacao.SetBool("Bater", false);
                Animacao.SetBool("Andar", false);
            }
        }

    }


    public void AnimaMorrer()
    {
        if (HP <= 0)
        {
            Animacao.SetBool("Morreu", true);
            Animacao.SetBool("Bater", false);
            Animacao.SetBool("Andar", false);
            Animacao.SetBool("Dano", false);
        }

    }

    private void OnTriggerEnter(Collider colidiu)
    {
        if (colidiu.gameObject.tag == "Explosao")
        {
            HP = 0;
        }

        if (colidiu.gameObject.tag == "BIG")
        {
            Dano();
            HP = HP - 100;
        }


        if (colidiu.gameObject.tag == "BIG2")
        {
            HP = 0;
        }

        if (colidiu.gameObject.tag == "MinhaEs")
        {
            Dano();
            HP = HP - 20;

        }

        if (colidiu.gameObject.tag == "ExplosaoEP5")
        {
            Dano();
            HP = 0;
        }

    }

    public void Destroi()
    {
        GJ.RecebePontos2(recompensa2);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision colidiu)
    {
       
    }
}

