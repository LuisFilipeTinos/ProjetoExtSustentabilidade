using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectLetter : MonoBehaviour
{

    public bool Win = false;

    public static CollectLetter Instance;  // Instância única para acessar o CollectLetter

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

    // Método para adicionar a letra à palavra
    public bool AddLetterToWord(char letter)
    {
        // Verifica se a próxima letra é a esperada
        if (currentWord.Length < targetWord.Length && letter == targetWord[currentWord.Length])
        {
            currentWord += letter; // Adiciona a letra à palavra atual
            wordText.text = currentWord; // Atualiza o texto na tela

            // Verifica se a palavra formada está completa
            if (currentWord == targetWord)
            {
                Win = true;
            }
            return true; // Indica que a letra foi coletada com sucesso
        }
        else
        {
            Debug.Log("Letra incorreta! Colete a próxima letra correta.");
            return false; // Indica que a letra não foi coletada por ser incorreta
        }
    }
}