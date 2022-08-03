using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Personagem : MonoBehaviour
{

    public Animator Animacao;
    public Atacar MeuAtaque;
    public Atacar MeuAtaque2;

    public int HP = 100;

    private Gerenciador GJ;

    public float forcaPulo;
    public bool podepular = true;
    public Rigidbody Corpo;

    float velX = 4;
    float velZ = 4;

    public bool podeAndar = true;
    public bool podeAndar2 = true;
    public bool podeAndar3 = true;
    public bool podeAndar4 = true;
    public GameObject BlocoAgarra;
    public GameObject Raio;

    float velX2 = 10;
    float velZ2 = 10;

    public Animacoes barraAzul;
    private bool terminaGolpe = false;
    private float tempogolpe = 0;

    public bool PegaES = false;
    public GameObject MinhaES;
    private int contES = 0;
    private bool ApertaE = false;
    public GameObject ESPADAO;
    public GameObject EfeitoES1;
    public GameObject EfeitoES2;
    private bool ParaEScondicao = false;
    private float ParaESPADATEMPO = 0;

    public GameObject PunhoUI;
    public GameObject EspadaUI;

    public GameObject EfeitoEP5;
    private bool AperteiE = false;
    public GameObject ExplosaoEP5;
    public GameObject Sombra;


    private bool DesativaExplo5 = false;
    private float tempoDesativaexplo5 = 0;

    private bool paraDano = false;
    private float tempodano = 0;

    public GameObject Aurora4;
    public int recompensa = 0;

    public HP_Portao Portao1;
    public HP_Portao2 Portao2;

    public bool MovimentoPersona = true;

    public GameObject CAM2;
    public GameObject CAM3;
    public bool QMorte = false;

    private bool ParaAga = false;
    private float TempoAga = 0;

    public float velocidade = 1;
    public float VelocidadeExterna = 0;

    private bool ComecaEscala2 = true;
    private bool chegaprafrente = false;
    private bool ParaEscadaW = true;

    public GameObject paredeEscada1;
    public GameObject paredeEscada2;
    public GameObject CamEscada;
    private float tempoCam = 0;
    private bool CondicaoCam = false;
    public GameObject TelaPreta;

    private int contFire = 0;

    public GameObject AndarSom;
    public GameObject PularSom;
    public GameObject CorrerSom;
    public GameObject QbutaoSom;
    private float tempoq = 0;
    public bool soltaq = false;
    public GameObject SomDano;
    public GameObject SomMorte;
    public GameObject SomBatalha;
    public bool ParaOutroSoms = false;
    public Camera7 Cam7;
    public GameObject VentoSom;
    public GameObject SocoSom;
    public GameObject MadeiraSom;
    public GameObject Somescala;
    public GameObject Sompegaes;
    public GameObject Somexplo;
    public GameObject espadasombate;
    public GameObject esp4par2;

    public float velX3 = 1;
    public float velZ3 = 1;
    public float velocidadeX3;
    public float velocidadeZ3;

    private bool teleporta = false;

    private float tempoCam2 = 0;
    private bool CondicaoCam2 = false;

    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
        Animacao = GetComponent<Animator>();
        Corpo = GetComponent<Rigidbody>();

    }

    void Update()
    {
       

        if (GJ.EstadoDoJogo() == true)
        {
                Atacar();
                AnimaMorrer();
                Pulo();

                if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.Joystick1Button0))
                {
                    soltaq = true;
                }

                if(soltaq == true)
                {
                     tempoq += Time.deltaTime;
                     if (tempoq >= 0.6)
                     {
                        QbutaoSom.SetActive(false);
                        tempoq = 0;
                        soltaq = false;
                     }
                }

                if (ParaEscadaW == true)
                {
                    if (Input.GetKeyUp(KeyCode.W))
                    {
                        paredeEscada1.GetComponent<BoxCollider>().enabled = false;
                        paredeEscada2.GetComponent<BoxCollider>().enabled = false;
                        Animacao.SetBool("Escalar", false);
                        Animacao.SetBool("EscalarParede", false);
                        MovimentoPersona = true;
                        Corpo.useGravity = true;
                        chegaprafrente = false;
                    }

                }

                if (CondicaoCam == true)
                {
                    tempoCam += Time.deltaTime;
                    if (tempoCam >= 1.7f)
                    {
                        TelaPreta.SetActive(true);
                    }

                    if (tempoCam >= 2.05f)
                    {
                        TelaPreta.SetActive(false);
                        CamEscada.SetActive(false);
                        CondicaoCam = false;
                        tempoCam = 0;
                    }
                }

            if (CondicaoCam2 == true)
            {
                tempoCam2 += Time.deltaTime;
                if (tempoCam2 >= 3.5f)
                {
                    TelaPreta.SetActive(true);
                }

                if (tempoCam2 >= 3.9f)
                {
                    TelaPreta.SetActive(false);
                    CondicaoCam2 = false;
                    tempoCam2 = 0;
                }
            }

            if (MovimentoPersona == true)
                {
                    if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.Joystick1Button10))
                    {
                        QbutaoSom.SetActive(true);
                        soltaq = true;
                        CAM2.GetComponent<CA1>().enabled = true;
                        CAM3.GetComponent<Camera2>().enabled = false;
                        contFire++;
                    }

                    if (contFire >= 2)
                    {
                        QbutaoSom.SetActive(true);
                        soltaq = true;
                        CAM2.transform.localRotation = Quaternion.Euler(0, 0, 0);
                        CAM2.GetComponent<CA1>().enabled = false;
                        CAM3.GetComponent<Camera2>().enabled = true;
                        contFire = 0;

                        //podegira.ViraPerso = false;
                    }

                    if (podeAndar == true)
                    {
                        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
                        {
                            float velocidadeX = Input.GetAxis("Horizontal") * velX;
                            float velocidadeZ = Input.GetAxis("Vertical") * velZ;
                            if (podeAndar3 == true)
                            {
                                Animacao.SetBool("Andar", true);
                                Animacao.SetBool("Ataque", false);
                                Animacao.SetBool("EP4", false);
                                Animacao.SetBool("Agachar", false);
                                AndarSom.SetActive(true);
                            }

                            Vector3 velChao = (transform.right * velocidadeX) + (transform.forward * velocidadeZ);
                           Corpo.velocity = new Vector3(velChao.x * 1, Corpo.velocity.y, velChao.z * 1);
                        }


                    }

                    if (barraAzul.FazPoder == true)
                    {
                        if (podeAndar2 == true)
                        {
                            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Joystick1Button4))
                            {

                                if (podeAndar4 == true)
                                {
                                    CorrerSom.SetActive(true);
                                    AndarSom.SetActive(false);
                                    Animacao.SetBool("Correr", true);
                                    Animacao.SetBool("Agachar", false);
                                    Animacao.SetBool("Andar", false);
                                    Animacao.SetBool("EP4", false);
                                    Animacao.SetBool("Ataque", false);

                                }
                                barraAzul.podeDiminuir = true;
                                Raio.SetActive(true);
                                float velocidadeX2 = Input.GetAxis("Horizontal") * velX2;
                                float velocidadeZ2 = Input.GetAxis("Vertical") * velZ2;
                                Vector3 velChao = (transform.right * velocidadeX2) + (transform.forward * velocidadeZ2);
                                Corpo.velocity = new Vector3(velChao.x * 2, Corpo.velocity.y, velChao.z * 2);
                            }
                        }
                    }



                    if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.Joystick1Button4) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
                    {
                        CorrerSom.SetActive(false);
                        AndarSom.SetActive(false);
                        barraAzul.podeDiminuir = false;
                        Raio.SetActive(false);
                        Animacao.SetBool("Correr", false);
                        Animacao.SetBool("Andar", false);

                    }

                    if (terminaGolpe == true)
                    {
                        tempogolpe += Time.deltaTime;
                        if (tempogolpe >= 1)
                        {
                            SocoSom.SetActive(false);
                            Animacao.SetBool("EP4", false);
                            Animacao.SetBool("Ataque", false);
                            MeuAtaque.possoAtacar = false;
                            MeuAtaque2.possoAtacar = false;
                            tempogolpe = 0;
                            terminaGolpe = false;
                        }
                    }

                    if (HP > 200)
                    {
                        HP = 200;
                    }

                    if (ApertaE == true)
                    {
                        if (AperteiE == true)
                        {
                            if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.UpArrow))
                            {
                                esp4par2.SetActive(false);
                                esp4par2.SetActive(true);
                                QbutaoSom.SetActive(true);
                                soltaq = true;
                                Aurora4.SetActive(true);
                                barraAzul.HPAzul -= 20;
                                Animacao.SetBool("EP5", true);
                           
                            }
                        }


                        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Joystick1Button5))
                        {
                            QbutaoSom.SetActive(true);
                            soltaq = true;
                            AperteiE = true;
                            MinhaES.SetActive(true);
                            Sombra.SetActive(false);
                            PegaES = true;
                            contES++;
                            EspadaUI.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                            EspadaUI.transform.localPosition = new Vector3(-372, -211f, 0f);

                            PunhoUI.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                            PunhoUI.transform.localPosition = new Vector3(-326, -211, 0f);

                            if (contES >= 2)
                            {
                                QbutaoSom.SetActive(true);
                                soltaq = true;
                                AperteiE = false;
                                EspadaUI.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                                EspadaUI.transform.localPosition = new Vector3(-326, -211f, 0f);

                                PunhoUI.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                                PunhoUI.transform.localPosition = new Vector3(-372, -211, 0f);
                                MinhaES.SetActive(false);
                                Sombra.SetActive(true);
                                PegaES = false;
                                contES = 0;
                            }
                        }


                    }

                    if (ParaEScondicao == true)
                    {
                        ParaESPADATEMPO += Time.deltaTime;
                        if (ParaESPADATEMPO > 1f)
                        {
                            espadasombate.SetActive(false);
                            Animacao.SetBool("EP4", false);
                            MinhaES.GetComponent<BoxCollider>().enabled = false;
                            EfeitoES1.SetActive(false);
                            EfeitoES2.SetActive(false);
                            ParaESPADATEMPO = 0;
                            ParaEScondicao = false;
                        }
                    }

                    if (DesativaExplo5 == true)
                    {
                        tempoDesativaexplo5 += Time.deltaTime;
                        if (tempoDesativaexplo5 >= 2f)
                        {
                            ExplosaoEP5.SetActive(false);
                            tempoDesativaexplo5 = 0;
                            DesativaExplo5 = false;
                        }


                    }


                    if (paraDano == true)
                    {
                        tempodano += Time.deltaTime;
                        if (tempodano > 0.5f)
                        {
                            Animacao.SetBool("Dano2", false);
                            SomDano.SetActive(false);
                            tempodano = 0;
                            paraDano = false;
                        }
                    }

                    if (ParaAga == true)
                    {
                        TempoAga += Time.deltaTime;
                        if (TempoAga >= 2f)
                        {
                            Animacao.SetBool("Agachar", false);
                            ParaAga = false;
                            TempoAga = 0;
                        }

                    }
            }
           
        }

            
    }

    void Pulo()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
                if (podepular == true)
                {
                    PularSom.SetActive(true);
                    AndarSom.SetActive(false);
                    CorrerSom.SetActive(false);
                    podepular = false;
                    Vector3 impulso = new Vector3(0f, forcaPulo, 0f);
                    Corpo.velocity = Corpo.velocity + impulso;
                    podeAndar3 = false;
                    podeAndar4 = false;
                    Animacao.SetBool("Pular", true);
                    Animacao.SetBool("Correr", false);
                    Animacao.SetBool("Andar", false);
                    Animacao.SetBool("Ataque", false);
                    Animacao.SetBool("Morrer", false);
                    Animacao.SetBool("EP4", false);


                }
            
        }
           
    }

    void Atacar()
    {
        if (Input.GetButton("Fire2") || Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            if(PegaES == true)
            {
                espadasombate.SetActive(true);
                MinhaES.GetComponent<BoxCollider>().enabled = true;
                Animacao.SetBool("EP4", true);
                ParaEScondicao = true;
                EfeitoES1.SetActive(true);
                EfeitoES2.SetActive(true);
                Animacao.SetBool("Andar", false);
                Animacao.SetBool("Pular", false);
                Animacao.SetBool("Morrer", false);
                Animacao.SetBool("Correr", false);
                Animacao.SetBool("Ataque", false);
                terminaGolpe = true;
            }

            else
            {
                SocoSom.SetActive(true);
                Animacao.SetBool("Ataque", true);
                Animacao.SetBool("Andar", false);
                Animacao.SetBool("Pular", false);
                Animacao.SetBool("Morrer", false);
                Animacao.SetBool("Correr", false);
                Animacao.SetBool("EP4", false);
            }
           
        }
    }

    public void ComecaAtaque()
    {
        MeuAtaque.possoAtacar = true;
        MeuAtaque2.possoAtacar = true;
        terminaGolpe = true;
    }


    public void Dano()
    {
           
        if (HP > 0)
        {
            if(HP >= 1)
            {
                HP = HP - 1;
                paraDano = true;
                SomDano.SetActive(true);
                Animacao.SetBool("Dano2", true);
                Animacao.SetBool("Ataque", false);
                Animacao.SetBool("Andar", false);
                Animacao.SetBool("Pular", false);
                Animacao.SetBool("Morrer", false);
                Animacao.SetBool("Correr", false);
                Animacao.SetBool("EP4", false);

            }
        }
    }

    public void AnimaMorrer()
    {
        if(HP <= 0)
        {
            SomMorte.SetActive(true);
            Cam7.PosicaoTarget = false;
            Animacao.SetBool("Morrer", true);
            Animacao.SetBool("Ataque", false);
            Animacao.SetBool("Andar", false);
            Animacao.SetBool("Pular", false);
            Animacao.SetBool("Correr", false);
            Animacao.SetBool("EP4", false);
        }
        
    }

    private void OnCollisionEnter(Collision colidiu)
    {
        if (colidiu.gameObject.tag == "Chao")
        {
                PularSom.SetActive(false);
                Animacao.SetBool("Pular", false);
                podepular = true;
                podeAndar3 = true;
                podeAndar4 = true;
            
           

        }

    }

    private void OnCollisionStay(Collision colidiu)
    {
       
    }

    private void OnTriggerStay(Collider colidiu)
    {

        if (colidiu.gameObject.tag == "Agarrar2")
        {

            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                Animacao.SetBool("Escalar", true);
                QbutaoSom.SetActive(true);
                ParaEscadaW = false;
                podepular = false;
                podeAndar = false;
                podeAndar2 = false;
                MovimentoPersona = false;
                Corpo.useGravity = false;
                Vector3 Para = new Vector3(0f, 0, 0f);
                Corpo.velocity = Corpo.velocity + Para;
                teleporta = true;
                CondicaoCam2 = true;


            }
        }

        if (colidiu.gameObject.tag == "Caixa2")
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                QbutaoSom.SetActive(true);
                colidiu.gameObject.GetComponent<CaixaMana>().LigaTri();
                Animacao.SetBool("Agachar", true);
                ParaAga = true;
            }
        }

        if (colidiu.gameObject.tag == "Caixa")
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                QbutaoSom.SetActive(true);
                colidiu.gameObject.GetComponent<CaixaVida>().LigaTri();
                Animacao.SetBool("Agachar", true);
                ParaAga = true;
            }
        }

        if (colidiu.gameObject.tag == "Portao")
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                QbutaoSom.SetActive(true);
                Portao1.PodeSubir = true;
            }
        }

        if (colidiu.gameObject.tag == "Portao2")
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                QbutaoSom.SetActive(true);
                Portao2.PodeSubir = true;
                SomBatalha.SetActive(true);
                ParaOutroSoms = true;
            }
        }

        if (colidiu.gameObject.tag == "Morte")
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                if (QMorte == true)
                {
                    QbutaoSom.SetActive(true);
                    GJ.Venceu();
                }
            }
        }

        if (colidiu.gameObject.tag == "Escada")
        {
            if (ComecaEscala2 == true)
            {
                if (velocidadeZ3 > 0)
                {
                    MadeiraSom.SetActive(true);
                    CorrerSom.SetActive(false);
                    AndarSom.SetActive(false);
                    QbutaoSom.SetActive(true);
                    paredeEscada1.GetComponent<BoxCollider>().enabled = true;
                    paredeEscada2.GetComponent<BoxCollider>().enabled = true;
                    Animacao.SetBool("EscalarParede", true);
                    Animacao.SetBool("Escalar", false);
                    Animacao.SetBool("Andar", false);
                    Animacao.SetBool("Pular", false);
                    Animacao.SetBool("Morrer", false);
                    Animacao.SetBool("Correr", false);
                    Animacao.SetBool("Ataque", false);
                    MovimentoPersona = false;
                    velocidade = Input.GetAxis("Vertical") * 3;
                    Corpo.velocity = new Vector2(Corpo.velocity.x, velocidade + VelocidadeExterna);

                }

                if (velocidade <= 0)
                {
                    QbutaoSom.SetActive(false);
                    MadeiraSom.SetActive(false);
                    Animacao.SetBool("Escalar", false);
                    Animacao.SetBool("EscalarParede", false);
                    MovimentoPersona = true;
                    Corpo.useGravity = true;
                    chegaprafrente = false;
                }
            }
               

            if (ComecaEscala2 == true)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    MadeiraSom.SetActive(true);
                    CorrerSom.SetActive(false);
                    AndarSom.SetActive(false);
                    QbutaoSom.SetActive(true);
                    paredeEscada1.GetComponent<BoxCollider>().enabled = true;
                    paredeEscada2.GetComponent<BoxCollider>().enabled = true;
                    Animacao.SetBool("EscalarParede", true);
                    Animacao.SetBool("Escalar", false);
                    Animacao.SetBool("Andar", false);
                    Animacao.SetBool("Pular", false);
                    Animacao.SetBool("Morrer", false);
                    Animacao.SetBool("Correr", false);
                    Animacao.SetBool("Ataque", false);
                    MovimentoPersona = false;
                    velocidade = Input.GetAxis("Vertical") * 3;
                    Corpo.velocity = new Vector2(Corpo.velocity.x, velocidade + VelocidadeExterna);

                   
                }

                if (Input.GetKeyUp(KeyCode.W))
                {
                    QbutaoSom.SetActive(false);
                    MadeiraSom.SetActive(false);
                    Animacao.SetBool("Escalar", false);
                    Animacao.SetBool("EscalarParede", false);
                    MovimentoPersona = true;
                    Corpo.useGravity = true;
                    chegaprafrente = false;
                }
            }

        }

        if (colidiu.gameObject.tag == "AtivaEs1")
        {
            QbutaoSom.SetActive(false);
            MadeiraSom.SetActive(false);
            ParaEscadaW = false;
            ComecaEscala2 = false;
            Animacao.SetBool("Escalar", true);
            Animacao.SetBool("EscalarParede", false);
            Animacao.SetBool("Andar", false);
            Animacao.SetBool("Pular", false);
            Animacao.SetBool("Morrer", false);
            Animacao.SetBool("Correr", false);
            Animacao.SetBool("Ataque", false);
            Corpo.velocity = new Vector2(0,0);
            Corpo.useGravity = false;
            chegaprafrente = true;
        }

       
    }


    private void OnCollisionExit(Collision collision)
    {

       
    }

    private void OnTriggerEnter(Collider colidiu)
    {
       

        if (colidiu.gameObject.tag == "EScolider")
        {
            Sompegaes.SetActive(false);
            Sompegaes.SetActive(true);
            ApertaE = true;
            Destroy(ESPADAO, 1f);
        }

        if (colidiu.gameObject.tag == "DanoMorte")
        {
            HP -= 5;
            Dano();
        }

        if (colidiu.gameObject.tag == "AtaqueMorte1")
        {
            Dano();
        }
        
        if (colidiu.gameObject.tag == "Chave")
        {
            GJ.RecebePontos(recompensa);
            Sompegaes.SetActive(false);
            Sompegaes.SetActive(true);
            soltaq = true;
        }

        if (colidiu.gameObject.tag == "ParaVento")
        {
            VentoSom.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider colidiu)
    {
        if (colidiu.gameObject.tag == "Escada")
        {
          MadeiraSom.SetActive(false);
          MovimentoPersona = true;
          Animacao.SetBool("EscalarParede", false);
          Animacao.SetBool("Escalar", false);
          Corpo.useGravity = true;
          chegaprafrente = false;
          paredeEscada1.GetComponent<BoxCollider>().enabled = false;
          paredeEscada2.GetComponent<BoxCollider>().enabled = false;
        }

        if (colidiu.gameObject.tag == "ParaVento")
        {
            VentoSom.SetActive(false);
        }
    }

    public void ParaAgachar()
    {
        Animacao.SetBool("Agachar", false);
        

    }

    public void ChamaGJmorreu()
    {
       // GJ.TelaPerdeu();
    }

    public void ParaEP5()
    {
        Somexplo.SetActive(false);
        Somexplo.SetActive(true);
        Animacao.SetBool("EP5", false);
        EfeitoEP5.SetActive(false);
        ExplosaoEP5.SetActive(true);
        DesativaExplo5 = true;
        Aurora4.SetActive(false);
    }

    public void LiberaEfeitoEP5()
    {
        EfeitoEP5.SetActive(true);
    }

    public void AumentaVida()
    {
        HP = HP + 30;
    }

    public void ChegaFrem()
    {
        if(chegaprafrente == true)
        {
            QbutaoSom.SetActive(false);
            MadeiraSom.SetActive(false);
            transform.localPosition = new Vector3(-52.3f, 13.47f, 88);
            ParaEscadaW = true;
            Animacao.SetBool("Escalar", false);
            paredeEscada1.GetComponent<BoxCollider>().enabled = false;
            paredeEscada2.GetComponent<BoxCollider>().enabled = false;
            Corpo.useGravity = true;
            MovimentoPersona = true;
            chegaprafrente = false;
            ComecaEscala2 = true;
            
        }
    }

    public void LigaCam()
    {
        if(chegaprafrente == true)
        {
            CamEscada.SetActive(true);
            CondicaoCam = true;
        }
        
    }

    public void SomSobe()
    {
        Somescala.SetActive(true);
    }

    public void ParaSomSobe()
    {
        Somescala.SetActive(false);
    }

    public void ParaSobeCasa()
    {
        if(teleporta == true)
        {
            transform.localPosition = new Vector3(-65.66f, 3.29f, 98.29f);
            teleporta = false;
            Animacao.SetBool("Escalar", false);
            Corpo.useGravity = true;
            MovimentoPersona = true;
            podepular = true;
            podeAndar = true;
            podeAndar2 = true;
        }
    }
}
