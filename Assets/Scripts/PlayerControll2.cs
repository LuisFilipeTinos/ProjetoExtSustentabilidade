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

    public Animator Anim; //Animação

    private void Awake()
    {
        rb2 = GetComponent<Rigidbody2D>(); //Pega o RigidBody2d
    }

    private void Update() //Método que será chamado a cada frame por segundo
    {

        horizontal2 = Input.GetAxis(horizontalInputAxis2); //Pega a movimentação do personagem do eixo X

        if (Input.GetKeyDown(KeyCode.W) && isGrounded2) //Verifica se a seta pra cima foi pressionada e se está no chão
        {
            rb2.AddForce(Vector2.up * 600);
        }

        isGrounded2 = Physics2D.OverlapCircle(groundCheck2.position, 0.2f, groundLayer2); //Verifica se algo está no chão, em um circulo invisivel
        //Caso esteja no chão, ele resulta em TRUE, se não, resultará em FALSE (significando que está fora do chão)
    }

    private void FixedUpdate() //Método para manipular a física
    {
        rb2.velocity = new Vector2(horizontal2 * speed2, rb2.velocity.y); //Lógica da física
    }

    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.D))
            Anim.SetBool("Isrun", true);

        else
            Anim.SetBool("Isrun", false);
    }



}
