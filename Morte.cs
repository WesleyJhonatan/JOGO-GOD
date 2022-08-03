using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Morte : MonoBehaviour
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

    public GameObject MeuDano;
    public int HP = 300;
    private bool paraDanoMorte = false;
    private float TempoDanoMorte = 0;
    private bool PodeDano = true;
    private float TempoDanoM = 0;

    public RectTransform ImagemHP;
    private float TempoEspecial1 = 0;
    public bool EspecialAcontece = false;
    public GameObject Aurora1;
    public LancaEspecialMorte PodeA;
    public GameObject Aurora2;
    public GameObject Brilho;
    public float TempoEspecial2 = 0;
    public float TempoEspecial3 = 0;
    private bool ParaEPM2 = false;

    public bool MovimentaMorte = false;

    public GameObject Camera1;
    public GameObject Camera2;
    private bool AtivaC1 = false;
    private float tempoC1 = 0;
    public Camera4 Cam4;

    private bool Animamo = true;
    public GameObject SomDano;
    private bool segue = true;

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
            Cameras();
            Animamorre();
            if (MovimentaMorte == true)
            {
                ImagemHP.sizeDelta = new Vector2(HP, 62f);

                TempoEspecial1 += Time.deltaTime;
                if (TempoEspecial1 >= 15)
                {
                    Aurora1.SetActive(true);
                    EspecialAcontece = true;
                    Agente.speed = 0;
                    MoverInimigo();
                    PodeA.possoAtacar = true;
                    TempoEspecial1 = 0;
                }

                if (ParaEPM2 == false)
                {
                    TempoEspecial2 += Time.deltaTime;
                    if (TempoEspecial2 >= 20)
                    {
                        AtivaC1 = true;
                        Aurora2.SetActive(true);
                        Brilho.SetActive(true);
                        TempoEspecial2 = 0;
                        ParaEPM2 = true;
                    }
                }


                if (ParaEPM2 == true)
                {
                    TempoEspecial3 += Time.deltaTime;
                    if (TempoEspecial3 >= 20)
                    {
                        Aurora2.SetActive(false);
                        Brilho.SetActive(false);
                        TempoEspecial3 = 0;
                        ParaEPM2 = false;
                    }
                }



                if (EspecialAcontece == false)
                {
                    if (podeAndar == true)
                    {
                        DistanciaHeroi = Vector3.Distance(transform.position, Heroi.transform.position);
                        if (DistanciaHeroi < 30 && DistanciaHeroi > 5)
                        {
                            Agente.speed = 2;
                            MoverInimigo();
                            Animador.SetBool("Andar", true);
                            Animador.SetBool("Bater", false);
                        }

                    }



                    if (DistanciaHeroi <= 5)
                    {
                        Animador.SetBool("Bater", true);
                        Animador.SetBool("Andar", false);
                    }


                    if (DistanciaHeroi > 31)
                    {
                        Agente.speed = 0;
                        Animador.SetBool("Bater", false);
                        Animador.SetBool("Andar", false);
                    }

                    if (paraDanoMorte == true)
                    {
                        TempoDanoMorte += Time.deltaTime;
                        if (TempoDanoMorte >= 1f)
                        {
                            Animador.SetBool("Dano", false);
                            SomDano.SetActive(false);
                            TempoDanoMorte = 0;
                            paraDanoMorte = false;
                        }
                    }

                    if (PodeDano == false)
                    {
                        TempoDanoM += Time.deltaTime;
                        if (TempoDanoM >= 1f)
                        {
                            PodeDano = true;
                            TempoDanoM = 0;
                        }
                    }
                }
            }
        }
            
    }


    private void MoverInimigo()
    {
        if(segue == true)
        {
            Agente.destination = Heroi.transform.position;
        }
        
    }

    private void OnTriggerEnter(Collider colidiu)
    {
        if (colidiu.gameObject.tag == "Explosao")
        {
            Animador.SetBool("Dano", true);
            paraDanoMorte = true;
            HP = HP - 10;
        }

        if (colidiu.gameObject.tag == "BIG")
        {
            Animador.SetBool("Dano", true);
            paraDanoMorte = true;
            HP = HP - 10;
        }


        if (colidiu.gameObject.tag == "BIG2")
        {
            Animador.SetBool("Dano", true);
            paraDanoMorte = true;
            HP = HP - 10;
        }

        if (colidiu.gameObject.tag == "MinhaEs")
        {
            Animador.SetBool("Dano", true);
            paraDanoMorte = true;
            HP = HP - 3;

        }

        if (colidiu.gameObject.tag == "ExplosaoEP5")
        {
            Animador.SetBool("Dano", true);
            paraDanoMorte = true;
            HP = HP - 10;
        }

    }


    public void AtivaDano()
    {
        MeuDano.SetActive(true);
    }

    public void DesativaDano()
    {
        MeuDano.SetActive(false);
    }

    public void Dano()
    {
       if(PodeDano == true)
        {
            if (HP >= 1)
            {
                PodeDano = false;
                HP = HP - 3;
                SomDano.SetActive(true);
                Animador.SetBool("Dano", true);
                Animador.SetBool("Bater", false);
                Animador.SetBool("Andar", false);
                paraDanoMorte = true;

                
            }
        }
            
        

    }

    public void Animamorre()
    {
       
            if (HP <= 0)
            {

                if(Animamo == true)
                {
                Animamo = false;
                MovimentaMorte = false;
                Animador.SetBool("Morrer", true);
                Animador.SetBool("Dano", false);
                Animador.SetBool("Bater", false);
                Animador.SetBool("Andar", false);
                }
              
            }
        
       
    }

    public void Cameras()
    {
       
        if (AtivaC1 == true)
        {
            MovimentaMorte = false;
            Camera1.SetActive(false);
            Camera2.SetActive(true);
            segue = false;

            tempoC1 += Time.deltaTime;
            if (tempoC1 >= 3f)
            {
                segue = true;
                MovimentaMorte = true;
                Camera1.SetActive(true);
                Camera2.SetActive(false);
                AtivaC1 = false;
                tempoC1 = 0;
            }
        }
    }

    public void LevantaCamera()
    {
        MeuDano.SetActive(false);
        MovimentaMorte = false;
        Camera1.SetActive(false);
        Cam4.GetComponent<Camera>().enabled = true;
        Cam4.PosicaoTarget = false;
    }
}