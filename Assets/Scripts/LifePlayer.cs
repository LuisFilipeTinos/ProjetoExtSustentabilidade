using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePlayer : MonoBehaviour
{

    public int life = 3;
    public int currentLife; //Váriaveis que controlam a vida do personagem
    public int knockbackForce = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        currentLife = life;
    }

    public void Damage()
    {

        currentLife -= 1; //Tira 1 de vida

        Debug.Log("Perdeu 1 vida - Total atual: " + currentLife);
        if (currentLife <= 0)
        {
            Debug.Log("Morreu");
        }

    }

    public void Knockback(Vector2 KnockbackDirection)
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.AddForce (KnockbackDirection.normalized * knockbackForce, ForceMode2D.Impulse);
        }

    }
}
