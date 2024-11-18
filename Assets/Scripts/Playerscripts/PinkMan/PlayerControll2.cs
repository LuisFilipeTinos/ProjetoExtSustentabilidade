using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll2 : MonoBehaviour
{
    [SerializeField] private float speed2 = 8f; //Define a velocidade
    private float horizontal2; //Pega o movimento horizontal
    private Rigidbody2D rb2;

    private string horizontalInputAxis2 = "Horizontal2";

    [SerializeField] private Transform groundCheck2; //Suporte que est� nos p�s do personagem
    [SerializeField] private LayerMask groundLayer2; //Layer do ch�o (GROUND)

    private bool isGrounded2; //Verificar se o personagem est� no ch�o

    public float knockbackForce2;
    public float knockbackCount2;
    public float knockbackTime2;

    public bool isKnockRight2;

    public Animator anim;

    private void Awake()
    {
        rb2 = GetComponent<Rigidbody2D>(); //Pega o RigidBody2d
    }

    private void Update() //M�todo que ser� chamado a cada frame por segundo
    {
        Jump(false);
    }
    private void FixedUpdate() //M�todo para manipular a f�sica
    {
        rb2.velocity = new Vector2(horizontal2 * speed2, rb2.velocity.y); //L�gica da f�sica
        KnockBack();
    }



    void KnockBack() //M�todo para o personagem sair voando apos levar dano
    {
        if (knockbackCount2 < 0)
        {
            Move(); //M�todo de pulo
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
        horizontal2 = Input.GetAxis(horizontalInputAxis2); //Pega a movimenta��o do personagem do eixo X
        if (Mathf.Abs(horizontal2) > 0.1f) //Verifica se est� andando
        {
            anim.SetBool("isRunning2", true); //Ativa a anima��o de andar
            if (horizontal2 > 0) //Verifica se est� indo para o lado direto no eixo X
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else if (horizontal2 < 0) //Verifica se est� indo para o lado esquerdo no eixo X
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            anim.SetBool("isRunning2", false); //Desativa a anima��o de andar
        }
    }

    public void Jump(bool HeadEnemy2)
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded2) //Verifica se a seta pra cima foi pressionada e se est� no ch�o
        {
            rb2.AddForce(Vector2.up * 600);
        }
        else if (HeadEnemy2 == true)
        {
            rb2.AddForce(Vector2.up * 350);
        }

        isGrounded2 = Physics2D.OverlapCircle(groundCheck2.position, 0.2f, groundLayer2); //Verifica se algo est� no ch�o, em um circulo invisivel
        //Caso esteja no ch�o, ele resulta em TRUE, se n�o, resultar� em FALSE (significando que est� fora do ch�o)
        
    }


}
