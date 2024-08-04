using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageManager : MonoBehaviour
{
    public GameObject package;
    public GameObject collectedPackagesParent;
    public static PackageManager instance;

    void Start()
    {  

    }

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

    void Update()
    {
        
    }

    public void Deliver()
    {
        foreach (Transform package in collectedPackagesParent.transform)
        {
            package.GetComponent<Package>().Deliver();
        }
    }   
    
}
