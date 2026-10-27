using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dengLuPD : MonoBehaviour
{
    public InputField yongHuMing;
    public InputField miMa;
    public GameObject cuoWuTiShi;

    public void dengLu()
    {
        if (yongHuMing.text == "admin" && miMa.text == "123") 
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            cuoWuTiShi.SetActive(true);
        }
    }
    public void chongZhi()
    {
        yongHuMing.text = "";
        miMa.text = "";
        cuoWuTiShi.SetActive(false);
    }
    public void tuiChu()
    {
        Application.Quit();
    } 
    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
