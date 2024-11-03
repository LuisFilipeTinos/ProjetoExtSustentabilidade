using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player")) //Identifica se o OBjeto de Tag Player colidiu
        {
            collision.gameObject.GetComponent<LifePlayer>().Damage();
        }
    }
}
