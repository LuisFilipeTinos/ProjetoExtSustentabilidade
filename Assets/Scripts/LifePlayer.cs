using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePlayer : MonoBehaviour
{

    public int life = 3;
    public int currentLife; //Váriaveis que controlam a vida do personagem
    
    // Start is called before the first frame update
    void Start()
    {
        currentLife = life;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
