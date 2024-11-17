using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamagePinkMan : MonoBehaviour
{
    private string namePinkMan2 = "PinkMan"; //Declara um texto com o nome do Player/Objeto PinkMan

    public HeartSystem heartPinkMan2; //Referencia o script de HeartSystem, para manipular os corações do PinkMan

    public PlayerControll2 ControllPinkMan2; //Cria um objeto para a classe de PlayerControll do PinkMan

    private bool isInvinciblePinkMan2 = false; //Controla a invencibilidade do PinkMan

    private BoxCollider2D boxColliderPinkMan;

    private bool HeadEnemy2;

    private void Start()
    {
        boxColliderPinkMan = GetComponent<BoxCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy"/*collision.gameObject.name == namePinkMan*/ && !isInvinciblePinkMan2) //Verifica se o objeto com o nome PinkMan foi tocado e se ele nao está invencivel
        {
            if (!isInvinciblePinkMan2)
            {
                boxColliderPinkMan.enabled = false;
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
        else if (collision.gameObject.tag == "HeadEnemy") //Verifica se o objeto encostou na cabeça do inimigo
        {
            HeadEnemy2 = true;
            GetComponent<PlayerControll2>().Jump(HeadEnemy2); //Chama o metodo Jump do objeto, passando como parametro um BOOL
        }
        else if (collision.gameObject.tag == "Void" || collision.gameObject.tag == "GiantEnemy") //Verifica se o objeto encostou no Void (Passou do limite do mapa)
        {
            GetComponent<HeartSystem>().KillDamage(); //Chama o método de dano do Void
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

        boxColliderPinkMan.enabled = true;
        isInvinciblePinkMan2 = false; //Desativa a invencibilidade
    }
}