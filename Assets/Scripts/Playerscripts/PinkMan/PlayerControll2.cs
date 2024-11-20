using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll2 : MonoBehaviour
{
    [SerializeField] private float speed2 = 8f; //Define a velocidade
    private float horizontal2; //Pega o movimento horizontal
    private Rigidbody2D rb2;

    private string horizontalInputAxis2 = "Horizontal2";

    [SerializeField] private Transform groundCheck2; //Suporte que está nos pés do personagem
    [SerializeField] private LayerMask groundLayer2; //Layer do chão (GROUND)

    private bool isGrounded2; //Verificar se o personagem está no chão

    public float knockbackForce2;
    public float knockbackCount2;
    public float knockbackTime2;

    public bool isKnockRight2;

    public Animator anim;

    private void Awake()
    {
        rb2 = GetComponent<Rigidbody2D>(); //Pega o RigidBody2d
    }

    private void Update() //Método que será chamado a cada frame por segundo
    {
        Jump(false);
    }
    private void FixedUpdate() //Método para manipular a física
    {
        rb2.velocity = new Vector2(horizontal2 * speed2, rb2.velocity.y); //Lógica da física
        KnockBack();
    }



    void KnockBack() //Método para o personagem sair voando apos levar dano
    {
        if (knockbackCount2 < 0)
        {
            Move(); //Método de pulo
        }
        else
        {
            if (isKnockRight2 == true)
            {
                rb2.velocity = new Vector2(-knockbackForce2, knockbackForce2); //Faz com que ele salte para a direita
            }
            if (isKnockRight2 == false)
            {
                rb2.velocity = new Vector2(knockbackForce2, knockbackForce2); //Faz com que ele salte para a esquerda
            }
        }
        knockbackCount2 -= Time.deltaTime; //O contador sera diminuido a cada momento
    }
    

    void Move()
    {
        horizontal2 = Input.GetAxis(horizontalInputAxis2); //Pega a movimentação do personagem do eixo X
        if (Mathf.Abs(horizontal2) > 0.1f) //Verifica se está andando
        {
            anim.SetBool("isRunning2", true); //Ativa a animação de andar
            if (horizontal2 > 0) //Verifica se está indo para o lado direto no eixo X
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (horizontal2 < 0) //Verifica se está indo para o lado esquerdo no eixo X
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            anim.SetBool("isRunning2", false); //Desativa a animação de andar
        }
    }

    public void Jump(bool HeadEnemy2)
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded2) //Verifica se a seta pra cima foi pressionada e se está no chão
        {
            rb2.AddForce(Vector2.up * 600);
        }
        else if (HeadEnemy2 == true)
        {
            rb2.AddForce(Vector2.up * 350);
        }

        isGrounded2 = Physics2D.OverlapCircle(groundCheck2.position, 0.2f, groundLayer2); //Verifica se algo está no chão, em um circulo invisivel
        //Caso esteja no chão, ele resulta em TRUE, se não, resultará em FALSE (significando que está fora do chão)
        
    }


}
