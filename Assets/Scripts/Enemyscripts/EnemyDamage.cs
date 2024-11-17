using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 50; // Saúde do inimigo

    // Método que aplica o dano ao inimigo
    public void TakeDamage(int damage)
    {
        health -= damage; // Subtrai o dano da vida do inimigo

        if (health <= 0)
        {
            Die(); // Chama a função de morte quando a vida chega a 0
        }
    }

    // Método que mata o inimigo
    private void Die()
    {
        // Aqui você pode adicionar animações, efeitos, ou qualquer outra coisa antes de destruir o inimigo
        Debug.Log("Inimigo morreu!");

        // Destroi o inimigo após a morte
        Destroy(gameObject);
    }
}