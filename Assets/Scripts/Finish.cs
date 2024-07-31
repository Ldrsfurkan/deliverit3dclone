using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{   
    public PackageManager packageManager;
    public PlayerController playerSc;
    void Start()
    {
        
        playerSc= GameObject.Find("Player").GetComponent<PlayerController>();
        packageManager= GameObject.Find("Package Manager").GetComponent<PackageManager>();
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
