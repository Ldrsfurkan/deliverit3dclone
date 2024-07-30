using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{   
    public GameObject packages;  
    public PackageManager packageManager;
    public PlayerController playerScript;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other)
    {
        packageManager.Deliver();
        playerScript.isGameEnd = true;
    }
}   
