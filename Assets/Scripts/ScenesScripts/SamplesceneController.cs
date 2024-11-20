using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    // Controle do menu
    public void StartGame()
    {
        // Codigo para iniciar uma cena, neste caso a de seleção de niveis.
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void Credits()
    {
        // Codigo para iniciar uma cena, aqui para abrir os créditos.
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        // debug.log() serve para mandar uma mensagem quando iniciado
        Debug.Log("O jogo fechou");
        // Codigo para fechar a aplicação
        Application.Quit();
    }

    public void Returnback()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

<<<<<<< HEAD:Assets/Scripts/SamplesceneController.cs
=======

>>>>>>> branchtemporario:Assets/Scripts/ScenesScripts/SamplesceneController.cs
}
