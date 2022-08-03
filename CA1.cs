using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CA1 : MonoBehaviour
{
    public Transform Player;
    public float Yoffset;
    [Range(0, 500)]
    public float Sensibility;
    [Range(0, 360)]
    public float LimitRotation;

    float rotX;
    float rotY;

    private Gerenciador GJ;

    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
    }

    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
           // float Mouse_X = Input.GetAxis("Mouse Y");
            float Mouse_Y = Input.GetAxis("Mouse X");

            //rotX -= Mouse_X * Sensibility * Time.deltaTime;
            rotY += Mouse_Y * Sensibility * Time.deltaTime;

            rotX = Mathf.Clamp(rotX, -LimitRotation, LimitRotation);

            transform.rotation = Quaternion.Euler(rotX, rotY, 0);

        }

    }

    private void LateUpdate()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
            transform.position = Player.position + Player.up * Yoffset;
        }
           
    }
}
