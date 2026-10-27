using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class li : MonoBehaviour
{
    Rigidbody cube;
    void Start()
    {
        cube = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            cube.AddForce(0f,1f,0f);
        }
        if (Input.GetKey(KeyCode.Alpha2 ))
        {
            cube.AddForce(0f, 0f, 1f);
        }
    }
}
