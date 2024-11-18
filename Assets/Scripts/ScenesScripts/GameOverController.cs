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

    void Update()
    {

        if (Playertwo == null && Playerone == null )
        {
            Debug.Log("gameover ativou");
            MainmenuBtt.SetActive(true);
            RestartBtt.SetActive(true);
            fade.SetActive(true);
            GameOvertxt.SetActive(true);
            Time.timeScale = 0;
        }
        
    }

    public void PlayAgain(int buildindex)
    {
        SceneManager.LoadScene(buildindex);
    }

    public void Resume()
    {
        Time.timeScale = 1; //Volta o tempo a correr

        RestartBtt.SetActive(false);
        fade.SetActive(false);
        ResumeBtt.SetActive(false);
        MainmenuBtt.SetActive(false);
    }
}
