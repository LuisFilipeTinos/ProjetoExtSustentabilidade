using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    //elementos da NextScreen
    [SerializeField] GameObject RestartBtt;
    [SerializeField] GameObject fade;
    [SerializeField] GameObject MainmenuBtt;
    [SerializeField] GameObject PauseBtt;
    [SerializeField] GameObject NextBtt;



    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
             MainmenuBtt.SetActive(true);
             RestartBtt.SetActive(true);
             fade.SetActive(true);
             NextBtt.SetActive(true);
             PauseBtt.SetActive(false);
        }

    }

}
