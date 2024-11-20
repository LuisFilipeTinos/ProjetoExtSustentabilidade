using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    Vector3 start;
    [SerializeField] float speed;
     Vector3 end;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("ReturnAfterEnd", 14f);
       
    }

 
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
         
    }

    private void ReturnAfterEnd()
    {

        SceneManager.LoadScene(0);
    }

}
