using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlimerMovement : MonoBehaviour
{
    public float speed = 1.5f; //Atribui uma velocidade
    public bool ground = true; //Verifica se o inimigo est� no ch�o
    public Transform groundCheck; //Pega o objeto que verifica o ch�o
    public LayerMask groundLayer; //Pega o layer do objeto
    public float direction = 1f;
    private SpriteRenderer spriteRendererEnemy;

    // Start is called before the first frame update
    void Start()
    {
        spriteRendererEnemy = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * direction * Time.deltaTime); //Movimenta o personagem para a direita
                                                                                 //ground = Physics2D.Linecast(groundCheck.position, transform.position, groundLayer); //Linecast --> Criar pontos imagin�rios na cena

        if (ground == false)
        {
            direction *= -1; //Muda para a dire��o contr�ria da atual
            FlipSprite();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) //Verifica se encostou com algum objeto cmo a tag de Obstacle
        {
            direction *= -1; //Muda para a dire��o contr�ria da atual
            FlipSprite(); //M�todo para alternar a dire��o visual do objeto
        }
    }

    void FlipSprite() //M�todo para alternar a dire��o visual do objeto
    {
        spriteRendererEnemy.flipX = !spriteRendererEnemy.flipX; //Altera a dire��o X visualmente do objeto em quest�o
    }
}
