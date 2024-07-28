using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{ 
    public GameObject PickUps;
    public GameObject money;  
    public int grandChildCount;
    public Vector3 moneyPos;

    
    void Start()
    {
      
    }
    void Update()
    {
        
    }
   
    void OnTriggerEnter(Collider other)
    {
        
        grandChildCount = PickUps.transform.childCount;
        CreateMoney();
        foreach (Transform child in other.transform){
            foreach (Transform grandChild in child){
                if(grandChild.CompareTag("Collectable")){
                Destroy(grandChild.gameObject);        
        }
            }
        }

    }
    void CreateMoney(){  
        //Vector3 moneyPos = new Vector3(PickUps.transform.position.x,PickUps.transform.position.y,PickUps.transform.position.z);
        int count = 0;
        while(count <= grandChildCount){
            count++;
            Vector3 moneyPos = new Vector3(PickUps.transform.position.x,PickUps.transform.position.y * count ,PickUps.transform.position.z);
            Instantiate(money,moneyPos,PickUps.transform.rotation,PickUps.transform);
            //Instantiate(money,Transform PickUps);
        }
    }
}
