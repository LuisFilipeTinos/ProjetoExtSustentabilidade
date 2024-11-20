using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectLetter : MonoBehaviour
{

    public bool Win = false;

    public static CollectLetter Instance;  // Inst�ncia �nica para acessar o CollectLetter

    public TextMeshProUGUI wordText;  // UI Text para mostrar a palavra formada
    public string targetWord = "AGUA";  // Palavra a ser formada pelo jogador
    private string currentWord = "";  // Palavra atual formada

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // M�todo para adicionar a letra � palavra
    public bool AddLetterToWord(char letter)
    {
        // Verifica se a pr�xima letra � a esperada
        if (currentWord.Length < targetWord.Length && letter == targetWord[currentWord.Length])
        {
            currentWord += letter; // Adiciona a letra � palavra atual
            wordText.text = currentWord; // Atualiza o texto na tela

            // Verifica se a palavra formada est� completa
            if (currentWord == targetWord)
            {
                Win = true;
            }
            return true; // Indica que a letra foi coletada com sucesso
        }
        else
        {
            Debug.Log("Letra incorreta! Colete a pr�xima letra correta.");
            return false; // Indica que a letra n�o foi coletada por ser incorreta
        }
    }
}