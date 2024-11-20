using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    private bool win;

    [SerializeField] GameObject RestartBtt;
    [SerializeField] GameObject fade;
    [SerializeField] GameObject MainmenuBtt;
    [SerializeField] GameObject PauseBtt;
    [SerializeField] GameObject NextBtt;


    // Start is called before the first frame update
    void Start()
    {
        if (CollectLetter.Instance != null)
            win = CollectLetter.Instance.Win;

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (win)
            {

                NextLevel();
                Debug.Log("Vc ganhou, passou de nivel");
            }
        }

    }

    private void NextLevel()
    {
        MainmenuBtt.SetActive(true);
        RestartBtt.SetActive(true);
        fade.SetActive(true);
        NextBtt.SetActive(true);
        PauseBtt.SetActive(false);
    }

}
