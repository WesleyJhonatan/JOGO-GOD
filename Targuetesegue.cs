using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targuetesegue : MonoBehaviour
{
    public GameObject Heroi;
    public float posX;
    public float posY;
    public float posZ;
    void Start()
    {
        
    }
    void Update()
    {
        Vector3 Destino = new Vector3(Heroi.transform.position.x + posX, Heroi.transform.position.y + posY, Heroi.transform.position.z + posZ);
        transform.position = Vector3.MoveTowards(transform.position, Destino, 70f);
    }
}
