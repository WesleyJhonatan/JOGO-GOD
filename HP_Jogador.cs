using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Jogador : MonoBehaviour
{
    public int meuHP;
    public RectTransform minhaImagem;
    private Personagem Dados;
    public Image minhaImagem2;
    public GameObject SomCoracao;
    private Gerenciador GJ;

    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
        Dados = GameObject.FindGameObjectWithTag("Player").GetComponent<Personagem>();
        minhaImagem = GetComponent<RectTransform>();
        minhaImagem2 = GetComponent<Image>();
        meuHP = Dados.HP * 3;
        minhaImagem.sizeDelta = new Vector2(meuHP, 35);
    }

    void Update()
    {
        if (GJ.EstadoDoJogo() == true)

        {
            meuHP = Dados.HP * 3;
            minhaImagem.sizeDelta = new Vector2(meuHP, 35);
            if (meuHP < 400 && meuHP > 200)
            {
                SomCoracao.SetActive(false);
                minhaImagem2.color = Color.yellow;
            }

            if (meuHP <= 200)
            {
                SomCoracao.SetActive(true);
                minhaImagem2.color = Color.red;
            }

            if (meuHP >= 400)
            {
                SomCoracao.SetActive(false);
                minhaImagem2.color = Color.green;
            }
        }

            
    }
}
