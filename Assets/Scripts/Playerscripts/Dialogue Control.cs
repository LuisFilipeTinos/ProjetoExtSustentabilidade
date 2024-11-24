using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj;
    public Image profile;
    public Text speechText;
    public Text actorNameText;

    [Header ("Settings")]
    public float typingSpeed;
    private string[] sentences;
    private int index;
    private bool isDialogueActive = false;  // Verifica se o diálogo está ativo
    private bool isTyping = false;  // Controle para saber se o texto está sendo digitado
    public bool canstartdialogueagain = true;



    public void Speech(Sprite p, string[] txt, string actorName)
    {
        if (!isDialogueActive)  // Só inicia se o diálogo não estiver ativo
        {
            isDialogueActive = true;  // Marca o diálogo como ativo
            dialogueObj.SetActive(true);
            canstartdialogueagain = false;
            profile.sprite = p;
            sentences = txt;
            actorNameText.text = actorName;
            StartCoroutine(TypeSentence());
        }
    }


    IEnumerator TypeSentence()
    {
        isTyping = true;

        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping=false;
    }

    public void NextSentence()
    {
        if (!isTyping)
        {
            if (speechText.text == sentences[index])
            {
                //ainda há textos
                if (index < sentences.Length - 1)
                {
                    index++;
                    speechText.text = "";
                    StartCoroutine(TypeSentence());

                }
                else //lido quando acaba os textos
                {
                    speechText.text = "";
                    index = 0;
                 
                    dialogueObj.SetActive(false);
                    isDialogueActive = false;
                    Invoke("ResetStartDialogue", 1);
                }

            }
        }

        else

        {
            // Se o texto não está completo, pula para a frase completa
            StopCoroutine(TypeSentence());  // Interrompe a digitação
            speechText.text = sentences[index];  // Exibe a frase completa


        }
    }
    void Update()
    {
        // Avançar com a tecla espaço
        if (Input.GetKeyDown(KeyCode.Space) && isDialogueActive && !isTyping)
        {
            NextSentence();
        }
    }
    void ResetStartDialogue() 
    {
        canstartdialogueagain = true;
    }

}
