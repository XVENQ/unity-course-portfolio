using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class triggerTree : MonoBehaviour {
    public AudioSource ads;//病毒消失音效
    public Text txt;//病毒数显示文本
    public GameObject panel;//病毒清除完毕显示面板
    int count;
    //脚本链接到第一人称上
	// Use this for initialization
	void Start () {
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "sick")//给生病树添加的标签
        {
            Destroy(other.gameObject);
            ads.Play();
            count++;
            txt.text = count.ToString();
            if (count == 6) {
                panel.SetActive(true);
            }
        }                    
    }
    public void ExitApp()
    {
        Application.Quit();//退出
    }
}
