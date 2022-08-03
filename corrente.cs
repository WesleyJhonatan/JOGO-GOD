using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corrente : MonoBehaviour
{
    public float x = -875;
    public float y = -654;
    private bool sobe = true;
    void Start()
    {
    }

    void Update()
    {
        if(sobe == true)
        {
            if (x <= -437 && y <= -216)
            {
                x += 2f;
                y += 2f;
                transform.localPosition = new Vector3(x, y, 0);


                if (x == -437 && y == -216)
                {
                    sobe = false;
                }
            }
        }

        if(sobe == false)
        {
            x -= 2f;
            y -= 2f;
            transform.localPosition = new Vector3(x, y, 0);

            if (x == -875 && y == -654)
            {
                sobe = true;
            }
        }
       
    }
}
