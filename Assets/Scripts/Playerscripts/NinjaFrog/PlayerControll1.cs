using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll1 : MonoBehaviour
{
    [SerializeField]private float speed = 8f; //Define a velocidade
    private float horizontal; //Pega o movimento horizontal
    private Rigidbody2D rb;

    private string horizontalInputAxis = "Horizontal";

    [SerializeField]private Transform groundCheck; //Suporte que está nos pés do personagem
    [SerializeField] private LayerMask groundLayer; //Layer do chão (GROUND)

    private bool isGrounded; //Verificar se o personagem está no chão

    public float knockbackForce;
    public float knockbackCount;
    public float knockbackTime;

    public bool isKnockRight;

    public Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //Pega o RigidBody2d
    }

    private void Update() //Método que será chamado a cada frame por segundo
    {
        Jump(false); //Método de pulo || Passa um valor false, pois não é por aqui que ele vai verificar se o objeto encostou ou nao na cabeça do inimigo
    }

    private void FixedUpdate() //Método para manipular a física
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); //Lógica da física
        KnockBack(); //Declarado no FIXEDUPDATE por envolver física, fazendo os comandos funcionarem

    }

    void KnockBack() //Método para o personagem sair voando apos levar dano
    {
        if (knockbackCount < 0)
        {
            Move(); //Método de pulo
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
        horizontal = Input.GetAxis(horizontalInputAxis); //Pega a movimentação do personagem do eixo X
        if (Mathf.Abs(horizontal) > 0.1f) //Verifica se está andando
        {
            anim.SetBool("isRunning", true); // Ativa a animação de andar

            if (horizontal > 0) //Verifica se está indo para o lado direto no eixo X
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // Vira para a direita
            }
            else if (horizontal < 0) //Verifica se está indo para o lado esquerdo do eixo x
            {
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); // Vira para a esquerda
            }
        }
        else
        {
            anim.SetBool("isRunning", false); // Desativa a animação de andar
        }

        
    }

   public void Jump(bool HeadEnemy) //Passa como parametro se é verdadeiro ou não no caso de ter tocado na cabeça do inimigo
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) //Verifica se a seta pra cima foi pressionada e se está no chão
        {
            rb.AddForce(Vector2.up * 600);
        }
        else if (HeadEnemy == true)
        {
            rb.AddForce(Vector2.up * 350);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); //Verifica se algo está no chão, em um circulo invisivel
        //Caso esteja no chão, ele resulta em TRUE, se não, resultará em FALSE (significando que está fora do chão)
    }


}
