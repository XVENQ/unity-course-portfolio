using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiaozhuan : MonoBehaviour
{
    public GameObject camera1,camera2,camera3;

    public void changeCube() 
    { 
        camera1.SetActive(true);
        camera2.SetActive(false);
        camera3.SetActive(false);
    }
    public void changeQiu() {
        camera2.SetActive(true);
        camera1.SetActive(false);
        camera3.SetActive(false);
    }
    public void changeYuanzhu() {
        camera3.SetActive(true);
        camera1.SetActive(false);
        camera2.SetActive(false);
    }
    public void tuichu() {
        Application.Quit();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
