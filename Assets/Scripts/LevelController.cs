using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] private int Level;    
    public void Selectlevel1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(Level);

    }


}
