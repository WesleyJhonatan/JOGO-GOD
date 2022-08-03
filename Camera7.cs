using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera7 : MonoBehaviour
{
    private Gerenciador GJ;
    public GameObject Heroi;
    public float posX;
    public float posY;
    public float posZ;
    public Transform characterHead;
    public bool PosicaoTarget = true;
    public GameObject SomParada;
    public GameObject SomFase;
    private bool parasobe = false;
    private float temposobe = 0;
    public GameObject camera2;
    public GameObject camera1;
    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
    }


    void Update()
    {
        if (GJ.EstadoDoJogo() == true)

        {
            if (PosicaoTarget == true)
            {
                transform.position = characterHead.position;
            }

            if (PosicaoTarget == false)
            {
                GetComponent<Camera>().enabled = true;
                SomParada.SetActive(true);
                SomFase.SetActive(false);
                Vector3 Destino = new Vector3(Heroi.transform.position.x + posX, Heroi.transform.position.y + posY, Heroi.transform.position.z + posZ);
                transform.position = Vector3.MoveTowards(transform.position, Destino, 0.1f);
                parasobe = true;
                camera2.SetActive(false);
                GetComponent<AudioListener>().enabled = true;
                camera1.GetComponent<AudioListener>().enabled = false;
            }


            if (parasobe == true)
            {
                temposobe += Time.deltaTime;
                if (temposobe >= 3)
                {
                    SomParada.SetActive(false);
                    GJ.TelaPerdeu();
                    temposobe = 0;
                    parasobe = true;
                }
            
                
            }

        }
    }

}
