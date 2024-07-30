using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{   
    public PackageManager packageManager;
    public PlayerController playerSc;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
     void OnTriggerEnter(Collider other)
    {
        packageManager.Deliver();
        playerSc.isGameEnd = true;
        Debug.Log(playerSc.totalMoney);
    }
}   
