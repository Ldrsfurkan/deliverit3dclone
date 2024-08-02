using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public GameObject parentObject;  
    public int collectedCount = 0;
    public float speed = 20.0f;
    public bool isGameEnd = false;
    public bool isDead = false;
    public bool isDamaged = false;
    public int totalMoney;

    public static PlayerController instance;

    private void Awake()
    {
        CreateInstance();
    }

    void CreateInstance()
    {
        if (!instance)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

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

    public void GetDamaged()
    {
        if (!isDamaged)
        {
            isDamaged = true;

            foreach (Transform child in parentObject.transform)
            {
                Destroy(child.gameObject, Random.Range(0.1f,0.5f));
                collectedCount = 0;
                totalMoney = 0;
            }
        }

        else
        {
            if (!isDead)
            {
                isDead = true;
                Debug.Log(isDead);
            }
            
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            var pack = other.GetComponent<Package>();
            if (!pack.isCollected)
            {
                other.transform.SetParent(parentObject.transform);           
                other.transform.localPosition = new Vector3(0, collectedCount, 0);                    
                collectedCount++;
            
                totalMoney += pack.money;
                pack.Collect();
            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            GetDamaged();
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            if (!isGameEnd && !isDead)
            {
                PackageManager.instance.Deliver();
            }
        }
    }
    
    
    
}
