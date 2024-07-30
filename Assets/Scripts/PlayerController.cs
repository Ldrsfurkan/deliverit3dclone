using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject parentObject;  
    public int collectedCount = 0;
    public float speed = 20.0f;
    public bool isGameEnd = false;
    public Package packageSc;
    public int totalMoney;
    
    void Start()
    {
         parentObject.transform.localPosition = new Vector3 (0,0,-1);
    }
    void Update()
    {
        Movement();     
    }

    void Movement(){
        if(!isGameEnd)
        {
         if(Input.GetKey(KeyCode.Space)){
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {          
            other.transform.SetParent(parentObject.transform);           
            other.transform.localPosition = new Vector3(0, collectedCount, 0);                    
            collectedCount++;  
            totalMoney += packageSc.money;
            
        }
    }
    
}
