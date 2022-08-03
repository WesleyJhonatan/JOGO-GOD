using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Azul : MonoBehaviour
{
    public float meuHP;
    public RectTransform minhaImagem;
    private Animacoes Dados;

    void Start()
    {
        Dados = GameObject.FindGameObjectWithTag("Player").GetComponent<Animacoes>();
        minhaImagem = GetComponent<RectTransform>();
        meuHP = Dados.HPAzul * 3;
        minhaImagem.sizeDelta = new Vector2(meuHP, 25);
    }

    void Update()
    {
        meuHP = Dados.HPAzul * 3;
        minhaImagem.sizeDelta = new Vector2(meuHP, 25);
    }
}