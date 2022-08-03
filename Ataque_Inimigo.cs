using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque_Inimigo : MonoBehaviour
{
    public bool possoAtacar = false;

    private Gerenciador GJ;

    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {

            if (possoAtacar == true)
            {
                Ataque();
            }
        }

       
    }

    public void Ataque()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 0.8f))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 0.8f, Color.red);
                hit.collider.gameObject.GetComponent<Personagem>().Dano();

            }

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 0.8f, Color.blue);
        }
    }
}
