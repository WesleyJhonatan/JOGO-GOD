using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2 : MonoBehaviour
{
    public Transform characterBody;
    public Transform characterHead;

    float sensitivityX = 5f;
    float sensitivityY = 5f;

    float rotationX = 0;
    float rotationY = 0;

    float angleYmin = -90;
    float angleYmax = 90;

    float smoothRotx = 0;
    float smoothRoty = 0;

    float smoothCoefx = 0.1f;
    float smoothCoefy = 0.1f;

    private Gerenciador GJ;
   

    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
    }

    private void LateUpdate()
    {
        if (GJ.EstadoDoJogo() == true)
        {
                //Cursor.lockState = CursorLockMode.None;
                Cursor.visible = false;
                transform.position = characterHead.position;
        }
           
    }

    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            
                float verticalDelta = Input.GetAxisRaw("Mouse Y") * sensitivityY;
                float horizontalDelta = Input.GetAxisRaw("Mouse X") * sensitivityX;

                smoothRotx = Mathf.Lerp(smoothRotx, horizontalDelta, smoothCoefx);
                smoothRoty = Mathf.Lerp(smoothRoty, verticalDelta, smoothCoefy);

                rotationX += smoothRotx;
                rotationY += smoothRoty;

                rotationY = Mathf.Clamp(rotationY, angleYmin, angleYmax);

                characterBody.localEulerAngles = new Vector3(0, rotationX, 0);
                transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            
        }
    }

}