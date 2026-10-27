using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;


public class XiaoMeiBS : MonoBehaviour
{
    int i;
    public Text jisuText;
    public GameObject jieshu;
    public AudioSource yinxiao;
    public void tuichu()
    {
        Application.Quit();
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "sick")
        {
            print("Åö×²");
            Destroy(other.gameObject);
            yinxiao.Play();
            i++;
            jisuText.text = i.ToString();
        }
        if (i == 8 )
        {
            jieshu.SetActive(true);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
