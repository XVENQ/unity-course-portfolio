using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DaKaiZiLiao : MonoBehaviour
{
    public GameObject ziLiao1;
    public void Dakai()
    {
        ziLiao1.SetActive(true);
    }
    public void guanBi()
    {
        ziLiao1.SetActive(false);
    }
    public void fanHuiCJ()
    {
        SceneManager.LoadScene("SampleScene");
    } 
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
