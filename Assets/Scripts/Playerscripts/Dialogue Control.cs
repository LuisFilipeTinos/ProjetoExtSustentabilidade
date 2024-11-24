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
    private bool isDialogueActive = false;  // Verifica se o di�logo est� ativo
    private bool isTyping = false;  // Controle para saber se o texto est� sendo digitado
    public bool canstartdialogueagain = true;



    public void Speech(Sprite p, string[] txt, string actorName)
    {
        if (!isDialogueActive)  // S� inicia se o di�logo n�o estiver ativo
        {
            isDialogueActive = true;  // Marca o di�logo como ativo
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
                //ainda h� textos
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
            // Se o texto n�o est� completo, pula para a frase completa
            StopCoroutine(TypeSentence());  // Interrompe a digita��o
            speechText.text = sentences[index];  // Exibe a frase completa


        }
    }
    void Update()
    {
        // Avan�ar com a tecla espa�o
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
