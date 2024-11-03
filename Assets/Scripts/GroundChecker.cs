using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class groundCheker : MonoBehaviour
{

    Character Player;

    // Update is called once per frame
    void Start()
    {
        Player = gameObject.transform.parent.gameObject.GetComponent<Character>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8) //Verifica se o colisor entrou em contato com a layer 8
        {
           // Player.isGrounded = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        
    }
}
