using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageManager : MonoBehaviour
{
    public GameObject package;
    public Package packageSc;
    int zOffset = 1;
    int xOffset = 2;
    

    void Start()
    {
        
        CreatePackages();
    }

    void Update()
    {
        
    }
    public void ChangeColor(Color _color) //calismiyo
    {   
        var packageRenderer = package.GetComponent<Renderer>();
        packageRenderer.sharedMaterial.SetColor("_Color", _color);

    }
    public void Deliver()
    {
        ChangeColor(Color.green);
    }
    public void SetTypeValue(int packageType)
    {
        if(packageType == 1)
        {
            packageSc.money = 100;
            ChangeColor(Color.green);
        }
        if(packageType == 2){
            packageSc.money = 200;
            ChangeColor(Color.yellow);
        }
        if(packageType == 3)
        {
            packageSc.money = 300;
            ChangeColor(Color.magenta);
        }
    }
    public void CreatePackages()
    {
        
        for(int i = 0; i<=10; i++)
        {
            xOffset += i;
            if( i%2 == 0)
            {
                SetTypeValue(2);
                Instantiate(package,new Vector3(xOffset,1,zOffset),package.transform.rotation);
            }
            else if(i%3 == 0)
            {
                SetTypeValue(3);
                zOffset = -1;
                Instantiate(package,new Vector3(xOffset,1,zOffset),package.transform.rotation);
            }
            else
            {
                SetTypeValue(1);
                Instantiate(package,new Vector3(xOffset,1,zOffset),package.transform.rotation);
            }

        }
    }
    
}
