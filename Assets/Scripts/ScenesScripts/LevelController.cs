using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{


    public void Selectlevel(int buildindex)
    {
        SceneManager.LoadScene(buildindex);

    }

}
