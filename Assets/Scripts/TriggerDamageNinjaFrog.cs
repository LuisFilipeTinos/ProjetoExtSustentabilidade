using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamageNinjaFrog : MonoBehaviour
{
    private string nameNinjaFrog2 = "NinjaFrog"; //Declara um texto com o nome do Player/Objeto NinjaFrog

    public HeartSystem heartNinjaFrog2; //Referencia o script de HeartSystem, para manipular os corações do NinjaFrog

    public PlayerControll1 ControllNinjaFrog2; //Cria um objeto para a classe de PlayerControll do NinjaFrog

    private bool isInvincibleNinjaFrog2 = false; //Controla a invencibilidade do NinjaFrog

    private BoxCollider2D boxColliderNinjaFrog;

    //private float invincibilityDuration2 = 1.0f; //Duração da invencibilidade
    //private float lastDamageTimeNinjaFrog2 = -Mathf.Infinity; //Marca o último momento em que o NinjaFrog levou dano

    private void Start()
    {
        boxColliderNinjaFrog = GetComponent<BoxCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" /*collision.gameObject.name == nameNinjaFrog*/ && !isInvincibleNinjaFrog2) //Verifica se o objeto com o nome NinjaFrog foi tocado e se ele nao está invencivel
        {
            if (!isInvincibleNinjaFrog2)
            {
                boxColliderNinjaFrog.enabled = false;
                StartCoroutine(HandleDamageNinjaFrog2());
                //lastDamageTimeNinjaFrog2 = Time.time; //Atualiza o tempo do último dano recebido 
            }

            if (collision.transform.position.x <= transform.position.x)
            {
                ControllNinjaFrog2.isKnockRight = true;
            }

            if (collision.transform.position.x > transform.position.x)
            {
                ControllNinjaFrog2.isKnockRight = false;
            }

        }
    }

    private IEnumerator HandleDamageNinjaFrog2()
    {
        isInvincibleNinjaFrog2 = true; //Ativa a invencibilidade
        ControllNinjaFrog2.knockbackCount = ControllNinjaFrog2.knockbackTime;
        heartNinjaFrog2.life--; //Diminui a vida do objeto NinjaFrog

        SpriteRenderer spriteRendererNinjaFrog = ControllNinjaFrog2.GetComponent<SpriteRenderer>();

        for (int i = 0; i < 5; i++)
        {
            spriteRendererNinjaFrog.enabled = false; //Desaparece o objeto
            yield return new WaitForSeconds(0.15f); //Aguarda alguns segundos
            spriteRendererNinjaFrog.enabled = true; //Aparece o objeto
            yield return new WaitForSeconds(0.15f); //Aguarda alguns segundos
        }

        //yield return new WaitForSeconds(invincibilityDuration2); //Aguarda alguns segundos

        boxColliderNinjaFrog.enabled = true;
        isInvincibleNinjaFrog2 = false; //Desativa a invencibilidade
    }
}