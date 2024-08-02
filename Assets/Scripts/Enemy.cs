using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 5.0f;
    private float distance = 6.0f;
    private bool isMoving = true;
    private Vector3 startPos;
    
    void Start()
    {
        startPos = transform.position;
       
    }
 
    void Update()
    {
        EnemyMovement();
    }
    
    void EnemyMovement()
    {
        if(isMoving)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if(Vector3.Distance(startPos,transform.position) >= distance)
            {
                    isMoving = false;
            }
        }
        
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if(Vector3.Distance(startPos, transform.position) >= distance)
            { 
                isMoving=true;
            }
        }
    }

}
