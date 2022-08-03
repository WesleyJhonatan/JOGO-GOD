using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LançaEspecial : MonoBehaviour
{

    public Especial _especial;
    public Transform localDeLancamento;
    public float forcaDeLancamento = 50;
    public float numeroDeGranadas = 10;
    public float tempoPorLancamento = 1;

    float cronometroGranada = 1;
    bool lancouGranada = false;

    private Gerenciador GJ;
    public bool possoAtacar = false;
    private void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();

    }
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {

            if(possoAtacar == true)
            {
                if (localDeLancamento && numeroDeGranadas >= 0 && !lancouGranada)
                {
                    possoAtacar = false;
                    numeroDeGranadas = 10;
                    lancouGranada = true;
                    Especial objGranada = Instantiate(_especial, localDeLancamento.position, transform.rotation) as Especial;
                    Rigidbody rbGranada = objGranada.GetComponent<Rigidbody>();
                    rbGranada.AddForce(localDeLancamento.transform.forward * forcaDeLancamento, ForceMode.Impulse);
                }
            }
          

            


          if (lancouGranada)
          {
           cronometroGranada += Time.deltaTime;
          }

          if (cronometroGranada >= tempoPorLancamento)
          {
            lancouGranada = false;
            cronometroGranada = 1;
          }

        }
            
    }
}

    
      

  
