using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gerenciador : MonoBehaviour
{

    public bool GameLigado = false;
    public GameObject TelaPause;
    public GameObject TelaGameOver;
    public GameObject TelaMenu;
    public GameObject TelaVencedor;
    public int pontos = 0;
    public int pontos2 = 0;
    public GameObject Guia1;
    public GameObject Guia2;

    public GameObject Guia3;
    public GameObject Guia4;

    public GameObject SomGame;
    public GameObject SomFase;
    public GameObject SomButao;
    public GameObject SomGameover;
    public GameObject SomVenceu;
    public Personagem Persona;
    public GameObject batalhasom;
    void Start()
    {
        GameLigado = false;

        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKey(KeyCode.Joystick1Button9))
        {
            TelaPause.SetActive(true);
            Cursor.visible = true;
            GameLigado = false;
            Time.timeScale = 0;
            SomButao.SetActive(false);
            SomButao.SetActive(true);

        }

        if (Input.GetKeyDown(KeyCode.F1) || Input.GetKey(KeyCode.Joystick1Button8))
        {
            Cursor.visible = true;
            GameLigado = false;
            Time.timeScale = 0;
            Guia3.SetActive(true);
            SomButao.SetActive(false);
            SomButao.SetActive(true);

        }

        if(Persona.ParaOutroSoms == true)
        {
            SomFase.SetActive(false);
            Persona.ParaOutroSoms = false;
        }

    }

    public bool EstadoDoJogo()
    {
        return GameLigado;
    }

    public void LigarJogo()

    {
        GameLigado = true;
        Time.timeScale = 1;

    }

    public void TelMenu()
    {
        TelaMenu.SetActive(true);
        SceneManager.LoadScene(0);
        SomGame.SetActive(true);
        SomFase.SetActive(false);
    }

    public void TelaPerdeu()
    {
       
        TelaGameOver.SetActive(true);
        Cursor.visible = true;
        GameLigado = false;
        Time.timeScale = 0;
        SomFase.SetActive(false);
        SomGameover.SetActive(true);
        batalhasom.SetActive(false);

    }

    public void BTtiraPause()
    {
            GameLigado = true;
            Time.timeScale = 1;
    }

    public void BTSair()
    {
        Application.Quit();
    }

    public void RecebePontos(int ponto)
    {
        pontos = pontos + ponto;
    }

    public int RetornaPontos()
    {
        return pontos;
    }

    public void RecebePontos2(int ponto2)
    {
        pontos2 = pontos2 + ponto2;
    }

    public int RetornaPontos2()
    {
        return pontos2;
    }

    public void Venceu()
    {
        Cursor.visible = true;
        TelaVencedor.SetActive(true);
        GameLigado = false;
        Time.timeScale = 0;
        SomVenceu.SetActive(true);
        SomGame.SetActive(true);
        Persona.SomBatalha.SetActive(false);
    }

    public void G1()
    {
        Cursor.visible = true;
        GameLigado = false;
        Time.timeScale = 0;
        Guia1.SetActive(true);
        SomFase.SetActive(true);
        SomGame.SetActive(false);
    }

    public void G2()
    {
        Cursor.visible = true;
        GameLigado = false;
        Time.timeScale = 0;
        Guia2.SetActive(true);
        SomFase.SetActive(true);
        SomGame.SetActive(false);

    }

    public void G3()
    {
        Cursor.visible = true;
        GameLigado = false;
        Time.timeScale = 0;
        Guia3.SetActive(true);
    }

    public void G4()
    {
        Cursor.visible = true;
        GameLigado = false;
        Time.timeScale = 0;
        Guia4.SetActive(true);

    }

    public void SomBotaoM()
    {
        SomButao.SetActive(false);
        SomButao.SetActive(true);
    }


}



