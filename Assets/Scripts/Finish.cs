using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{   
    public PackageManager packageManager;
    public PlayerController playerSc;
    public Vector3 playerStartPos = new Vector3(-1,1,0);
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
        foreach (Transform child in other.transform) // toplanları silme
        {
            foreach (Transform grandChild in child)
            {
                Destroy(grandChild.gameObject);
            }    
        }
        CreateNewLevel();
        Destroy(gameObject);
    }
    void CreateNewLevel()
    {
        if(playerSc.isGameEnd == true)
        {
            packageManager.packageCount +=5;
            //GameObject.Find("Player").transform.position = playerStartPos;
            packageManager.CreateScene();
            playerSc.isGameEnd = false;
        }
    }
}   
