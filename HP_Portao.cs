using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Portao : MonoBehaviour
{
    public RectTransform minhaImagem;
    private Gerenciador GC;
    public int cont = 0;
    private bool Sobevermelho = true;
    public GameObject GuardaChaves;
    public bool PodeSubir = false;
    public GameObject Portao;
    private float YY = 10;
    private bool podeApertar = false;

    void Start()
    {
        GC = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
        minhaImagem = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (GC.EstadoDoJogo() == true)
        {
            if (Sobevermelho == true)
            {
                minhaImagem.sizeDelta = new Vector2(GC.RetornaPontos2(), 35);
                cont = GC.RetornaPontos2();
            }

            if (cont >= 150)
            {
                GuardaChaves.SetActive(true);
                Sobevermelho = false;
                minhaImagem.sizeDelta = new Vector2(300, 35);
                GetComponent<Mensagem>().enabled = true;
                podeApertar = true;

            }

            if(podeApertar == true)
            {
                if (PodeSubir == true)
                {
                    Portao.transform.localPosition = new Vector3(-4.43f, YY += 0.05f, -13.59f);

                    if (YY >= 14)
                    {
                        PodeSubir = false;
                    }
                }
            }
           

        }
       
       

        

       
    }
}