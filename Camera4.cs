using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera4 : MonoBehaviour
{
    private Gerenciador GJ;
    public GameObject Heroi;
    public float posX;
    public float posY;
    public float posZ;
    public Transform characterHead;
    public bool PosicaoTarget = true;
    public GameObject Camera1;
    private bool parasobe = false;
    private float temposobe = 0;
    public GameObject BotaoMorte;
    public GameObject AuroraMorte;
    public Personagem Persona;
    public GameObject Sfere;



    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
    }


    void Update()
    {
        if (GJ.EstadoDoJogo() == true)

        {
            if(PosicaoTarget == true)
            {
                transform.position = characterHead.position;
            }
            
            if(PosicaoTarget == false)
            {
                Vector3 Destino = new Vector3(Heroi.transform.position.x + posX, Heroi.transform.position.y + posY, Heroi.transform.position.z + posZ);
                transform.position = Vector3.MoveTowards(transform.position, Destino, 0.3f);
                parasobe = true;
                GetComponent<AudioListener>().enabled = true;

            }
             
            if(parasobe == true)
            {
                temposobe += Time.deltaTime;
                if(temposobe >= 3)
                {
                    Camera1.SetActive(true);
                    GetComponent<AudioListener>().enabled = false;
                    GetComponent<Camera>().enabled = false;
                    BotaoMorte.SetActive(true);
                    AuroraMorte.SetActive(true);
                    Persona.QMorte = true;
                    Sfere.GetComponent<SphereCollider>().enabled = true;

                }
              
            }
               // transform.eulerAngles = new Vector3(80, 0, 0);
               
        }
    }

}
