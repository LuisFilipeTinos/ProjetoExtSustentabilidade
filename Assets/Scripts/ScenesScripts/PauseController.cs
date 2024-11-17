using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] GameObject RestartBtt;
    [SerializeField] GameObject fade;
    [SerializeField] GameObject MainmenuBtt;
    [SerializeField] GameObject ResumeBtt;
    public void Pause()
    {
        Time.timeScale = 0; //faz o tempo da cena parar

        RestartBtt.SetActive(true);
        fade.SetActive(true);
        ResumeBtt.SetActive(true);
        MainmenuBtt.SetActive(true);
    }



}
