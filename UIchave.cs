using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIchave : MonoBehaviour
{
    public Text meuTexto;
    private Gerenciador GC;


    // Start is called before the first frame update
    void Start()
    {
        meuTexto = GetComponent<Text>();

        GC = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GC.EstadoDoJogo() == true)
        {
            meuTexto.text = GC.RetornaPontos().ToString();
        }
    }
}

