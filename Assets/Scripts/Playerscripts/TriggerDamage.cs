using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    private string nameNinjaFrog = "NinjaFrog"; //Declara um texto com o nome do Player/Objeto NinjaFrog
    private string namePinkMan = "PinkMan"; //Declara um texto com o nome do Player/Objeto PinkMan
    
    public HeartSystem heartNinjaFrog; //Referencia o script de HeartSystem, para manipular os corações do NinjaFrog
    public HeartSystem heartPinkMan; //Referencia o script de HeartSystem, para manipular os corações do PinkMan

    public PlayerControll1 ControllNinjaFrog; //Cria um objeto para a classe de PlayerControll do NinjaFrog
    public PlayerControll2 ControllPinkMan; //Cria um objeto para a classe de PlayerControll do PinkMan

    private bool isInvincibleNinjaFrog = false; //Controla a invencibilidade do NinjaFrog
    private bool isInvinciblePinkMan = false; //Controla a invencibilidade do PinkMan

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == nameNinjaFrog && !isInvincibleNinjaFrog) //Verifica se o objeto com o nome NinjaFrog foi tocado e se ele nao está invencivel
        {
            StartCoroutine(HandleDamageNinjaFrog());
            if (collision.transform.position.x <= transform.position.x)
            {
                ControllNinjaFrog.isKnockRight = true;
            }

            if (collision.transform.position.x > transform.position.x)
            {
                ControllNinjaFrog.isKnockRight = false;
            }
        }

        if (collision.gameObject.name == namePinkMan && !isInvinciblePinkMan) //Verifica se o objeto com o nome PinkMan foi tocado e se ele nao está invencivel
        {
            StartCoroutine(HandleDamagePinkMan());
            if (collision.transform.position.x <= transform.position.x)
            {
                ControllPinkMan.isKnockRight2 = true;
            }

            if (collision.transform.position.x > transform.position.x)
            {
                ControllPinkMan.isKnockRight2 = false;
            }
        }
    }

    private IEnumerator HandleDamageNinjaFrog()
    {
        isInvincibleNinjaFrog = true; //Ativa a invencibilidade
        ControllNinjaFrog.knockbackCount = ControllNinjaFrog.knockbackTime;
        heartNinjaFrog.life--; //Diminui a vida do objeto NinjaFrog

        SpriteRenderer spriteRendererNinjaFrog = ControllNinjaFrog.GetComponent<SpriteRenderer>();

        for (int i = 0; i < 5; i++)
        {
            spriteRendererNinjaFrog.enabled = false; //Desaparece o objeto
            yield return new WaitForSeconds(0.15f); //Aguarda alguns segundos
            spriteRendererNinjaFrog.enabled = true; //Aparece o objeto
            yield return new WaitForSeconds(0.15f); //Aguarda alguns segundos
        }

        yield return new WaitForSeconds(0.5f); //Aguarda alguns segundos
        isInvincibleNinjaFrog = false; //Desativa a invencibilidade
    }

    private IEnumerator HandleDamagePinkMan()
    {
        isInvinciblePinkMan = true; //Ativa a invencibilidade
        ControllPinkMan.knockbackCount2 = ControllPinkMan.knockbackTime2;
        heartPinkMan.life--; //Diminui a vida do objeto PinkMan

        SpriteRenderer spriteRendererPinkMan = ControllPinkMan.GetComponent<SpriteRenderer>();

        for (int i = 0; i < 5; i++)
        {
            spriteRendererPinkMan.enabled = false; //Desaparece o objeto
            yield return new WaitForSeconds(0.15f); //Aguarda alguns segundos
            spriteRendererPinkMan.enabled= true; //Aparece o objeto
            yield return new WaitForSeconds(0.15f); //Aguarda alguns segundos
        }

        yield return new WaitForSeconds(0.5f); //Aguarda alguns segundos
        isInvinciblePinkMan = false; //Desativa a invencibilidade
    }
}