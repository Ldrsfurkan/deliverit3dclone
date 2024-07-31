using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageManager : MonoBehaviour
{
    public GameObject package;
    public GameObject enemy;
    public GameObject finishLine;
    public GameObject plane;
    public Package packageSc;
    Vector3 lastPackagePosition;
    int zOffset = 1;
    int xOffset = 2;
    public int packageCount;
    

    void Start()
    {  
        CreatePackages();
        //CreateEnemy();
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
        
        for(int i = 0; i<=packageCount; i++) 
        {
            xOffset += i;
            if( i%2 == 0)
            {
                SetTypeValue(2);
                GameObject newPackage = Instantiate(package,new Vector3(xOffset,1,zOffset),package.transform.rotation);
                lastPackagePosition = newPackage.transform.position;
            }
            else if(i%3 == 0)
            {
                SetTypeValue(3);
                zOffset = -1;
                GameObject newPackage = Instantiate(package,new Vector3(xOffset,1,zOffset),package.transform.rotation);
                lastPackagePosition = newPackage.transform.position;
                Instantiate(enemy,new Vector3(xOffset,2,0),enemy.transform.rotation); //enemy create
            }
            else
            {
                SetTypeValue(1);
                GameObject newPackage = Instantiate(package,new Vector3(xOffset,1,zOffset),package.transform.rotation);
                lastPackagePosition = newPackage.transform.position;
            }
        }
        lastPackagePosition.x +=4;
        Instantiate(finishLine,lastPackagePosition,finishLine.transform.rotation); // create finishline
        // create plane
        plane.transform.localScale = new Vector3(lastPackagePosition.x/4,0.1f,3);
        Instantiate(plane,new Vector3(lastPackagePosition.x,0,lastPackagePosition.z),plane.transform.rotation); 
       
    }
    /*public void CreateEnemy()
    {
        int x =3;
        if(packageCount % 5 == 0)
        {
            for (int i = 1; i < packageCount; i+=4)
            {
                x*=i;
                Instantiate(enemy,new Vector3(x,2,0),enemy.transform.rotation);
            }
        }
    }*/
    
}
