using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverscene : MonoBehaviour
{

    [SerializeField] GameObject RestartBtt;
    [SerializeField] GameObject fade;
    [SerializeField] GameObject MainmenuBtt;
    [SerializeField] GameObject Playerone;
    [SerializeField] GameObject Playertwo;
    [SerializeField] GameObject GameOvertxt;
    [SerializeField] GameObject ResumeBtt;
    [SerializeField] GameObject PauseBtt;



     void Start()
     {
        Time.timeScale = 1;
     }
    void Update()
    {

        if (Playertwo == null && Playerone == null )
        {

            MainmenuBtt.SetActive(true);
            RestartBtt.SetActive(true);
            fade.SetActive(true);
            GameOvertxt.SetActive(true);
            PauseBtt.SetActive(false);
            Time.timeScale = 0;
        }
        
    }

    public void PlayAgain(int buildindex)
    {
        SceneManager.LoadScene(buildindex);

    }

    public void Pause()
    {
        Time.timeScale = 0;

        MainmenuBtt.SetActive(true);
        RestartBtt.SetActive(true);
        fade.SetActive(true);
        ResumeBtt.SetActive(true);
        PauseBtt.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1; //Volta o tempo a correr

        fade.SetActive(false);
        RestartBtt.SetActive(false);
        ResumeBtt.SetActive(false);
        MainmenuBtt.SetActive(false);
        PauseBtt.SetActive(true);
    }
}
