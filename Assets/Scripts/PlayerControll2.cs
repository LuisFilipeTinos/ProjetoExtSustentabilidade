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

    public Animator Anim; //Anima��o

    private void Awake()
    {
        rb2 = GetComponent<Rigidbody2D>(); //Pega o RigidBody2d
    }

    private void Update() //M�todo que ser� chamado a cada frame por segundo
    {

        horizontal2 = Input.GetAxis(horizontalInputAxis2); //Pega a movimenta��o do personagem do eixo X

        if (Input.GetKeyDown(KeyCode.W) && isGrounded2) //Verifica se a seta pra cima foi pressionada e se est� no ch�o
        {
            rb2.AddForce(Vector2.up * 600);
        }

        isGrounded2 = Physics2D.OverlapCircle(groundCheck2.position, 0.2f, groundLayer2); //Verifica se algo est� no ch�o, em um circulo invisivel
        //Caso esteja no ch�o, ele resulta em TRUE, se n�o, resultar� em FALSE (significando que est� fora do ch�o)
    }

    private void FixedUpdate() //M�todo para manipular a f�sica
    {
        rb2.velocity = new Vector2(horizontal2 * speed2, rb2.velocity.y); //L�gica da f�sica
    }

    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.D))
            Anim.SetBool("Isrun", true);

        else
            Anim.SetBool("Isrun", false);
    }



}
