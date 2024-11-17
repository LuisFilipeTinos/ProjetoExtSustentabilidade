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

    private bool HeadEnemy;

    private void Start()
    {
        boxColliderNinjaFrog = GetComponent<BoxCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !isInvincibleNinjaFrog2) //Verifica se o objeto com o nome NinjaFrog foi tocado e se ele nao está invencivel
        {
            if (!isInvincibleNinjaFrog2)
            {
                boxColliderNinjaFrog.enabled = false;
                StartCoroutine(HandleDamageNinjaFrog2());
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
        else if (collision.gameObject.tag == "HeadEnemy") //Verifica se o objeto encostou na cabeça do inimigo
        {
            HeadEnemy = true;
            GetComponent<PlayerControll1>().Jump(HeadEnemy); //Chama o metodo Jump do objeto, passando como parametro um BOOL
        }
        else if (collision.gameObject.tag == "Void" || collision.gameObject.tag == "GiantEnemy") //Verifica se o objeto encostou no Void (Passou do limite do mapa)
        {
            GetComponent<HeartSystem>().KillDamage(); //Chama o método de dano do Void
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

        boxColliderNinjaFrog.enabled = true;
        isInvincibleNinjaFrog2 = false; //Desativa a invencibilidade
    }
}