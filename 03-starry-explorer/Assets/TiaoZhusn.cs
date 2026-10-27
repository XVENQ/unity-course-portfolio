using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TiaoZhusn : MonoBehaviour
{
    public void KStangshuo()
    {
        SceneManager.LoadScene("MuXing");
    }
    public void TCtanshuo()
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
