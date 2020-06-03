using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour
{
    public GameObject Pause;
    public GameObject Bg;
    public GameObject I;
    public GameObject AB;
    public GameObject Joystick;
   

   public void OnClick()
    {
        
            LeanTween.scale(Pause, new Vector3(0, 0, 0), 0.5f);
            LeanTween.scale(Bg, new Vector3(0, 0, 0), 0f);
            LeanTween.scale(I, new Vector3(0, 0, 0), 0.5f);
            LeanTween.scale(AB, new Vector3(0, 0, 0), 0.5f);
            LeanTween.scale(Joystick, new Vector3(0, 0, 0), 0.5f).setOnComplete(show);
  

    }
    void show()
    {
       
        {
            Pause.SetActive(false);
            Bg.SetActive(true);
            I.SetActive(false);
            AB.SetActive(false);
            Joystick.SetActive(false);
            LeanTween.scale(Bg, new Vector3(0, 0, 0), 0f).setOnComplete(Click);
        } 
    }
     void Click()
    {
        
        LeanTween.scale(Bg, new Vector3(1f, 1f, 1f), 0.5f);

        
        
    }
   
    public void Voltar()
    {
            Pause.SetActive(true);
            I.SetActive(true);
            AB.SetActive(true);
            Joystick.SetActive(true);
            LeanTween.scale(Bg, new Vector3(0, 0, 0), 0.3f).setOnComplete(VoltarComplete);


    }
    void VoltarComplete()
    {
        Bg.SetActive(false);
        LeanTween.scale(Pause, new Vector3(1, 1, 1), 0.5f);
        LeanTween.scale(I, new Vector3(1, 1, 1), 0.5f);
        LeanTween.scale(AB, new Vector3(1, 1, 1), 0.5f);
        LeanTween.scale(Joystick, new Vector3(1.5f, 1.5f, 1.5f), 0.5f);

        
    }
    public void VoltarMenu()
    {
        SceneManager.LoadScene(0);
    }
   

}
