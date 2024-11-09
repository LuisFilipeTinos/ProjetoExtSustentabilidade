using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 50; // Sa�de do inimigo

    // M�todo que aplica o dano ao inimigo
    public void TakeDamage(int damage)
    {
        health -= damage; // Subtrai o dano da vida do inimigo

        if (health <= 0)
        {
            Die(); // Chama a fun��o de morte quando a vida chega a 0
        }
    }

    // M�todo que mata o inimigo
    private void Die()
    {
        // Aqui voc� pode adicionar anima��es, efeitos, ou qualquer outra coisa antes de destruir o inimigo
        Debug.Log("Inimigo morreu!");

        // Destroi o inimigo ap�s a morte
        Destroy(gameObject);
    }
}