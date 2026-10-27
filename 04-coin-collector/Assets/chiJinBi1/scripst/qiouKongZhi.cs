using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class qiouKongZhi : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 10f;
    public GameObject perfab_jinbi;
    public int ShuLiang;
    Vector3 pos;
    private GameObject[] jinbis;
    void Start()
    {
        for (int i  = 0; i < ShuLiang; i++) 
        { 
        pos.x = Random.Range(-19f, 19f);
        pos.z = Random.Range(-19f, 19f);
        pos.y = 1.1f;
        
        Instantiate(perfab_jinbi, pos, Quaternion.identity);
        }
        jinbis = GameObject.FindGameObjectsWithTag("jinbi");
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(h*speed*Time.deltaTime, 0, v * speed*Time.deltaTime);
        foreach (var item in jinbis) 
        { 
            if (item != null)
            {
                if (Vector3.Distance(item.transform.position,transform.position) < 1f)
                {
                    Destroy(item);
                      
                }

            }
        }
    }
}
