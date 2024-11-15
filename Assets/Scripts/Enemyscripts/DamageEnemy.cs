using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DamageEnemy : MonoBehaviour
{
    public int lifeEnemy = 2; //Vida do inimigo
    private bool invincibleEnemy = false; //Atribui falso para a invencibilidade do inimigo
    private float timeInvincible = 1.5f; //Atribui o tempo de invencibilidade do inimigo
    private SpriteRenderer spriteRenderer; //Pega o SpriteRenderer do inimigo
    private Color originalColor; 
    public float blinkEnemy = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //Pega o SpriteRenderer do objeto
        originalColor = spriteRenderer.color; //Pega a cor do objeto
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HeadEnemy") && !invincibleEnemy)
        {
            GameObject enemy = collision.gameObject.transform.parent.gameObject;
            string nameEnemy = collision.gameObject.name;
            Damage(enemy);
        }
    }

    private void Damage(GameObject enemy)
    {
        if (lifeEnemy == 2)
        {
            lifeEnemy--;
            InvincibleEnable();
            StartCoroutine(RedColor());
        }
        else if (lifeEnemy == 1)
        {
            lifeEnemy--;
            DeathEnemy(enemy);
        }
    }

    private void InvincibleEnable()
    {
        invincibleEnemy = true;
        Invoke("InvincibleDisable", timeInvincible);
    }

    private void InvincibleDisable()
    {
        invincibleEnemy = false;
    }

    private void DeathEnemy(GameObject enemy)
    {
        Destroy(enemy);
    }

    private IEnumerator RedColor()
    {
        float timePassed = 0f;
        while (timePassed < timeInvincible)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(blinkEnemy);
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(blinkEnemy);
            timePassed += blinkEnemy * 2;
        }
    }
}
