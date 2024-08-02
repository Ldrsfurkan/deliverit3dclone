using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    public int money;
    public Color color;
    public bool isCollected = false;
    public bool isDelivered = false;
    void Start()
    {
        GetComponent<MeshRenderer>().material.color = color;
    }

    public void Collect()
    {
        isCollected = true;
    }

    public void Deliver()
    {
        isDelivered = true;
        GetComponent<MeshRenderer>().material.color = Color.green;
        Destroy(gameObject,0.5f);
    }



    
    void Update()
    {
        
    }
}
