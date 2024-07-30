using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{   
    public GameObject packages;  
    //public Package PackageScript;
    public PlayerController PlayerScript;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other)
    {
        //PackageScript.Deliver();
        PlayerScript.isGameEnd = true;
    }
}   
