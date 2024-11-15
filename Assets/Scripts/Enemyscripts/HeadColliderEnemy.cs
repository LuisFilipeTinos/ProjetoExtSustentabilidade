using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadColliderEnemy : MonoBehaviour
{
    public int damageAmount = 10; // Quantidade de dano a ser aplicada no inimigo

    // Método de detecção de colisão
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica se o objeto colidido é o jogador
        {
            // Obtém o script de inimigo do objeto pai
            Enemy enemy = transform.parent.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damageAmount); // Aplica o dano ao inimigo
            }
        }
    }
}