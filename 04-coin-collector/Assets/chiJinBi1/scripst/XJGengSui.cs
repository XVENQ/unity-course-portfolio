using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XJGengSui : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform balltransform;
    Vector3 offset;
    void Start()
    {
        offset = transform.position-balltransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = balltransform.position+offset;
    }
}
