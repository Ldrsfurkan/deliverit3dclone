using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{ 
    public GameObject parentObject;  
    public float yOffset = 1f;
    private int collectedCount = 0;
    void Start()
    {
        parentObject.transform.localPosition = new Vector3 (0,-0.6f,-1.2f);
    }
   
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {          
            other.transform.SetParent(parentObject.transform);           
            other.transform.localPosition = new Vector3(0, collectedCount * yOffset, 0);            
           collectedCount++;
        }
    }
}
