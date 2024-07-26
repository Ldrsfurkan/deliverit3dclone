using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        Movement();
    }

    void Movement(){
         if(Input.GetKey(KeyCode.Space)){
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
