using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll1 : MonoBehaviour
{
    [SerializeField]private float speed = 8f; //Define a velocidade
    private float horizontal; //Pega o movimento horizontal
    private Rigidbody2D rb;

    private string horizontalInputAxis = "Horizontal";

    [SerializeField]private Transform groundCheck; //Suporte que est� nos p�s do personagem
    [SerializeField] private LayerMask groundLayer; //Layer do ch�o (GROUND)

    private bool isGrounded; //Verificar se o personagem est� no ch�o

    public float knockbackForce;
    public float knockbackCount;
    public float knockbackTime;

    public bool isKnockRight;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //Pega o RigidBody2d
    }

    private void Update() //M�todo que ser� chamado a cada frame por segundo
    {
        Jump(); //M�todo de pulo
    }

    private void FixedUpdate() //M�todo para manipular a f�sica
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); //L�gica da f�sica
        KnockBack(); //Declarado no FIXEDUPDATE por envolver f�sica, fazendo os comandos funcionarem

    }

    void KnockBack() //M�todo para o personagem sair voando apos levar dano
    {
        if (knockbackCount < 0)
        {
            Move(); //M�todo de pulo
        }
        else
        {
            if (isKnockRight == true)
            {
                rb.velocity = new Vector2(-knockbackForce, knockbackForce); //Faz com que ele salte para a direita
            }
            if (isKnockRight == false)
            {
                rb.velocity = new Vector2(knockbackForce, knockbackForce); //Faz com que ele salte para a esquerda
            }
        }
        knockbackCount -= Time.deltaTime; //O contador sera diminuido a cada momento
    }

    void Move()
    {
        horizontal = Input.GetAxis(horizontalInputAxis); //Pega a movimenta��o do personagem do eixo X
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) //Verifica se a seta pra cima foi pressionada e se est� no ch�o
        {
            rb.AddForce(Vector2.up * 600);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); //Verifica se algo est� no ch�o, em um circulo invisivel
        //Caso esteja no ch�o, ele resulta em TRUE, se n�o, resultar� em FALSE (significando que est� fora do ch�o)
    }


}
