using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamagePinkMan : MonoBehaviour
{
    private string namePinkMan2 = "PinkMan"; //Declara um texto com o nome do Player/Objeto PinkMan

    public HeartSystem heartPinkMan2; //Referencia o script de HeartSystem, para manipular os corações do PinkMan

    public PlayerControll2 ControllPinkMan2; //Cria um objeto para a classe de PlayerControll do PinkMan

    private bool isInvinciblePinkMan2 = false; //Controla a invencibilidade do PinkMan

    //private float invincibilityDuration2 = 1.0f; //Duração da invencibilidade
    //private float lastDamageTimePinkMan2 = -Mathf.Infinity; //Marca o último momento em que o PinkMan levou dano

    private void Start()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy"/*collision.gameObject.name == namePinkMan*/ && !isInvinciblePinkMan2) //Verifica se o objeto com o nome PinkMan foi tocado e se ele nao está invencivel
        {
            if (!isInvinciblePinkMan2)
            {
                StartCoroutine(HandleDamagePinkMan2());
                //lastDamageTimePinkMan2 = Time.time; //Atualiza o tempo do último dano recebido 
            }

            if (collision.transform.position.x <= transform.position.x)
            {
                ControllPinkMan2.isKnockRight2 = true;
            }

            if (collision.transform.position.x > transform.position.x)
            {
                ControllPinkMan2.isKnockRight2 = false;
            }
        }
    }

    private IEnumerator HandleDamagePinkMan2()
    {
        isInvinciblePinkMan2 = true; //Ativa a invencibilidade
        ControllPinkMan2.knockbackCount2 = ControllPinkMan2.knockbackTime2;
        heartPinkMan2.life--; //Diminui a vida do objeto PinkMan

        SpriteRenderer spriteRendererPinkMan = ControllPinkMan2.GetComponent<SpriteRenderer>();

        for (int i = 0; i < 5; i++)
        {
            spriteRendererPinkMan.enabled = false; //Desaparece o objeto
            yield return new WaitForSeconds(0.15f); //Aguarda alguns segundos
            spriteRendererPinkMan.enabled = true; //Aparece o objeto
            yield return new WaitForSeconds(0.15f); //Aguarda alguns segundos
        }

        //yield return new WaitForSeconds(invincibilityDuration2); //Aguarda alguns segundos

        isInvinciblePinkMan2 = false; //Desativa a invencibilidade
    }
}