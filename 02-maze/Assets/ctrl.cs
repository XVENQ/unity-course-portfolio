using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ctrl : MonoBehaviour
{
    Rigidbody rigidbody;
    int i;
    public Text jiSuQi;
    public GameObject ShengLi;
    public void TuiChu()
    {
        print("´¥·¢ÍË³ö");
        Application.Quit();
    }

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rigidbody.AddForce(h, 0 , v);
    }
    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "jingBi")
        {
            Destroy(collision.gameObject);
            i++;
            print(i);
            jiSuQi.text = i.ToString();
            if (i == 12)
            {
                ShengLi.SetActive(true);
            }
        } 
        if (collision.gameObject.tag == "qiang")
        {
            collision.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
