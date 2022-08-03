using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacar : MonoBehaviour
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
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2))
        {
            if(hit.collider.gameObject.tag == "Inimigo")
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 2, Color.red);
                hit.collider.gameObject.GetComponent<Inimigo>().Dano();

            }

            if (hit.collider.gameObject.tag == "Morte")
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 2, Color.red);
                hit.collider.gameObject.GetComponent<Morte>().Dano();

            }

        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 2, Color.blue);
        }
    }


}
