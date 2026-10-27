using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XuanZhuan : MonoBehaviour
{
    // Start is called before the first frame update
    public float FuDu = 1f;
    public float ShuDu = 1f;
    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * ShuDu) * FuDu;
        transform.position = new Vector3 (startPos.x, newY, startPos.z);
        transform.Rotate(0, 30*Time.deltaTime*2, 0);
    }
}
