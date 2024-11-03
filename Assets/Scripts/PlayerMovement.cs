using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //private float horizontal;
    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveplayerx, moveplayery;
    [SerializeField]private float speed = 8f;
    [SerializeField]private float jump = 5f;

    public float groundCheckDistance = 0.2f;
    public LayerMask groundLayer;

    private Vector2 direction;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }

        rb.velocity = new Vector2(moveplayerx * speed, rb.velocity.y);
    }

    void Move()
    {
        //horizontal = Input.GetAxis("Horizontal");
        moveplayerx = Input.GetKey("d") ? 1 : Input.GetKey("a") ? -1 : 0;
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jump);
        Debug.Log("Pulou");

        //direction = new Vector2(moveplayerx, rb.velocity.y);
        //rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        
    }

    private void OnDrawGizmos()
    {
        // Visualização do Raycast no editor
        Gizmos.color = isGrounded ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundCheckDistance);
    }

    /*private void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        //rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        //rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }*/

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Está no chão");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("Não está no chão");
        }
    }*/
}
