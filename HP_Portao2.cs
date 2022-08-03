using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Portao2 : MonoBehaviour
{
    private Gerenciador GC;
    private int cont = 0;
    public bool podeApertar = false;
    public bool PodeSubir = false;
    private float YY = 10;
    private float YY2 = 15;
    public GameObject Portao;
    public Personagem Andar;
    public GameObject Portao2;
    private bool Portao3 = false;
    public Morte Movi;
    public GameObject Camera5;

   
    void Start()
    {
        GC = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
    }

    void Update()
    {
        if (GC.EstadoDoJogo() == true)
        {
           cont = GC.RetornaPontos();
            

            if (cont >= 7)
            {
                GetComponent<Mensagem>().enabled = true;
                podeApertar = true;

            }

            if (podeApertar == true)
            {
                if (PodeSubir == true)
                {
                    Andar.MovimentoPersona = false;
                    Camera5.SetActive(true);
                    Portao.transform.localPosition = new Vector3(-4.93f, YY += 0.05f, -43.11f);
                    Portao3 = true;
                    if (YY >= 14)
                    {
                        PodeSubir = false;
                    }
                }
            }

            if(Portao3 == true)
            {
                Portao2.transform.localPosition = new Vector3(-4.71f, YY2 -= 0.05f, -39.59f);
                if (YY2 <= 10)
                {
                    Portao3 = false;
                    Camera5.SetActive(false);
                    Andar.MovimentoPersona = true;
                    Movi.MovimentaMorte = true;


                }

            }


        }






    }
}