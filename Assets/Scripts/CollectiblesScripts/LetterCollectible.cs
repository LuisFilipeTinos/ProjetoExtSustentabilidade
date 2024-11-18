using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterCollectible : MonoBehaviour
{
    public char letter; // A letra que este item representa

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Tenta adicionar a letra à palavra; só destrói o objeto se for a letra correta
            bool collected = CollectLetter.Instance.AddLetterToWord(letter);
            if (collected)
            {
                Destroy(gameObject); // Destrói o item se a letra estiver correta
            }
            else
            {
                Debug.Log("Essa letra não é a próxima correta.");
            }
        }
    }
}
