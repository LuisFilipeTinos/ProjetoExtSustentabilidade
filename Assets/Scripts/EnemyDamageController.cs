using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour
{
    private BoxCollider2D boxColliderEnemy;

    void Start()
    {
        // Acessa o filho diretamente pelo nome (certifique-se de que o nome do objeto está correto)
        Transform filho = transform.Find("headDamage");

        if (filho != null)
        {
            boxColliderEnemy = filho.GetComponent<BoxCollider2D>();
        }

        if (boxColliderEnemy == null)
        {
            Debug.LogWarning("BoxCollider2D não encontrado no filho!");
        }
    }

    void OnTriggerEnter2D/*OnCollisionEnter2D*/ (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("O inimigo foi atingido!");
        }
    }
}