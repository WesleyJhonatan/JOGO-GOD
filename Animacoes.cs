using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacoes : MonoBehaviour
{
    public Animator Animacao;
    public GameObject Bola;
    public GameObject Aurora1;
    public GameObject Aurora2;
    public GameObject Aurora3;
    public GameObject Big;
    public LançaEspecial MeuEspecial1;

    public GameObject Big3;
    public GameObject LocalSaida;

    public float HPAzul = 100;
    public bool podeDiminuir = false;
    public bool FazPoder = true;
    public GameObject SomEps1pt1;
    public GameObject SomEps1pt2;
    public GameObject SomEps1pt3;
    private bool ativasompt3 = false;
    private float tempoEp1Pt3 = 0;
    public GameObject Somq;
    public Personagem soltaq;
    public GameObject esp2par1;
    public GameObject esp3par1;
    private float tempo = 0;
    private bool parasomep3 = false;
    void Start()
    {
        Animacao = GetComponent<Animator>();
    }

    void Update()
    {
        if(podeDiminuir == true)
        {
            HPAzul -= 0.05f;
        }

        if(FazPoder == true)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Somq.SetActive(true);
                soltaq.soltaq = true;
                Animacao.SetBool("EP1", true);
                Aurora1.SetActive(true);
                HPAzul = HPAzul - 10;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                esp2par1.SetActive(true);
                Somq.SetActive(true);
                soltaq.soltaq = true;
                Animacao.SetBool("EP2", true);
                Aurora2.SetActive(true);
                HPAzul = HPAzul - 10;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {               
                Somq.SetActive(true);
                soltaq.soltaq = true;
                Animacao.SetBool("EP3", true);
                Aurora3.SetActive(true);
                HPAzul = HPAzul - 10;
            }
        }

        if(HPAzul <= 0)
        {
            FazPoder = false;
            HPAzul = 0;
        }

        if(HPAzul > 100)
        {
            HPAzul = 100;
        }

        if(HPAzul >= 1)
        {
            FazPoder = true;
        }

        if(ativasompt3 == true)
        {
            tempoEp1Pt3 += Time.deltaTime;
            if (tempoEp1Pt3 >= 1.5f)
            {
                SomEps1pt3.SetActive(false);
                SomEps1pt3.SetActive(true);
                ativasompt3 = false;
                tempoEp1Pt3 = 0;
            }
        }

        if(parasomep3 == true)
        {
            tempo += Time.deltaTime;
            if (tempo >= 5.5f)
            {
                esp3par1.SetActive(false);
                SomEps1pt2.SetActive(false);
                SomEps1pt2.SetActive(true);
                tempo = 0;
                parasomep3 = false;

            }
        }

    }

    public void LigaBola()
    {
        Bola.SetActive(true);
        SomEps1pt1.SetActive(true);
    }

    public void DesligaBola()
    {
        SomEps1pt2.SetActive(false);
        SomEps1pt2.SetActive(true);
        SomEps1pt1.SetActive(false);
        Bola.SetActive(false);
        MeuEspecial1.possoAtacar = true;
        ativasompt3 = true;
    }
    public void ParaEP1()
    {
        Animacao.SetBool("EP1", false);
        Bola.SetActive(false);
        Aurora1.SetActive(false);
    }

    public void ParaEP2()
    {
        esp2par1.SetActive(false);
        Animacao.SetBool("EP2", false);
        Big.SetActive(false);
        Aurora2.SetActive(false);
    }

    public void LigaEfeito2()
    {
        Big.SetActive(true);
    }

    public void ParaEP3()
    {
        Animacao.SetBool("EP3", false);
        Aurora3.SetActive(false);
    }

    public void LigaEfeito3()
    {
        esp3par1.SetActive(true);
        parasomep3 = true;
        Instantiate(Big3, LocalSaida.transform.position, Quaternion.identity);
    }

   public void AumentaMana()
    {
        HPAzul = HPAzul + 30;
    }
}
