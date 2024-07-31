using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public PlayerController playerController;
    private float speed = 5.0f;
    private float distance = 6.0f;
    private bool isMoving = true;
    private Vector3 startPos;
    
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        player = GameObject.Find("Player");
        startPos = transform.position;
       
    }
 
    void Update()
    {
        EnemyMovement();
        RemoveEnemy();
    }
    
    void OnTriggerEnter(Collider other){ // toplanları silme
        foreach (Transform child in other.transform){
            foreach (Transform grandChild in child){
                Destroy(grandChild.gameObject);
                playerController.collectedCount = 0; 
                playerController.totalMoney = 0 ;         
            }
        }

    }
    void EnemyMovement()
    {
        if(isMoving){
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
                if(Vector3.Distance(startPos,transform.position) >= distance){
                    isMoving = false;
        }
        }
        else{
            transform.Translate(Vector3.back * speed * Time.deltaTime);
                if(Vector3.Distance(startPos, transform.position) >= distance){
                    isMoving=true;
            }
            
        }

    }
    void RemoveEnemy() 
    {
        if(player.transform.position.x + 5 > transform.position.x)
        {
            Destroy(gameObject);
        }
    }
}
