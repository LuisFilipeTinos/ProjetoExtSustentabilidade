using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
    Vector3 start;
    [SerializeField] float speed;
     Vector3 end;

    // Start is called before the first frame update
    void Start()
    {
        start = transform.position;
        end = transform.position * (-8) ;
    }

 
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if(this.transform.position.y > end.y) 
        {
            this.transform.position = start;
        }
         
    }


}
