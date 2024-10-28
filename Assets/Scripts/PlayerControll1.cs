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

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //Pega o RigidBody2d
    }

    private void Update() //Método que será chamado a cada frame por segundo
    {
        
        horizontal = Input.GetAxis(horizontalInputAxis); //Pega a movimentação do personagem do eixo X

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) //Verifica se a seta pra cima foi pressionada e se está no chão
        {
             rb.AddForce(Vector2.up * 600);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); //Verifica se algo está no chão, em um circulo invisivel
        //Caso esteja no chão, ele resulta em TRUE, se não, resultará em FALSE (significando que está fora do chão)
    }

    private void FixedUpdate() //Método para manipular a física
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); //Lógica da física
    }

}
