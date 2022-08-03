using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigCollider : MonoBehaviour
{
    public SphereCollider myCollider;
    

    void Start()
    {
        myCollider = GetComponent<SphereCollider>();
        Destroy(this.gameObject, 6f);

    }

    void Update()
    {
        myCollider.radius += 0.05f;
    }
}
