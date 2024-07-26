using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public GameObject parentObject;
    private Vector3 objectOffset = new Vector3(0,1,0);
    private Vector3 nextPos;

    
    void Start()
    {
        
    }

    void Update()
    {
        nextPos = parentObject.transform.position;
    }
    void OnTriggerEnter(Collider other){
        //if(gameObject.CompareTag("Collectable")){
        transform.SetParent(parentObject.transform);
        transform.position = nextPos;
        nextPos += objectOffset;
        //gameObject.tag = "Collected";
        //}
       
        
    }
}
