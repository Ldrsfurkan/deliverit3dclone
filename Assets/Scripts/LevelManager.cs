using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int levelID = 0;
    public int gap;
    private int step = 1;
    public GameObject packagePrefab;
    public GameObject enemyPrefab;
    public GameObject finishPrefab;
    public List<List<int>> levels;
    public static LevelManager instance;

     private void Awake()
    {
        CreateInstance();
    }

    void CreateInstance()
    {
        if (!instance)
        {
            instance = this;
        } 
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }
    
    void Start()
    {
        //var newLevel = new List<int>();
        // 0-bosluk, 1-package, 2-enemy, 3-finish
        //levels = new List<int>()
        levels = new List<List<int>>()
        {
            new List<int>() {1,1,1,1,1,2,1,1,1,1,1,3},
            new List<int>() {1,1,1,2,1,0,2,1,1,1,3},
            new List<int>() {1,1,1,2,1,2,1,2,1,1,1,3},
            new List<int>() {1,1,1,2,1,2,1,2,1,1,1,1,2,1,2,1,3},
            new List<int>() {1,2,1,2,1,2,1,2,1,1,1,1,1,1,2,3}
        };
        
        CreateLevel();
    }

    public void CreateLevel()
    {
        foreach (var l in levels[levelID])
        {
            if (l == 0)
            {
                
            }
            else if (l == 1)
            {
                var r = Random.Range(0, 3);
                var newPackage = Instantiate(packagePrefab);
                newPackage.GetComponent<ModelSelector>().SetModel(r);
                newPackage.transform.position = new Vector3(0, 0, gap * step);
            }
            else if(l == 2)
            {
                var newEnemy = Instantiate(enemyPrefab);
                newEnemy.transform.position = new Vector3(-7, 0, gap * step);
            }
            else
            {
                var newFinish = Instantiate(finishPrefab);
                newFinish.transform.position = new Vector3(0, 0, gap * step);
            }
            step++;
        }
    }
    public void newLevel()
    {
        GameObject[] allObj = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObj)
        {
            if(obj.CompareTag("environment") || obj.CompareTag("Player"))
            {
                continue;
            }
            Destroy(obj);
        }
        step = 0;
        levelID++;
        CreateLevel();

    }
    
}
