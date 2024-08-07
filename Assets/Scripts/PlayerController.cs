using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public Transform[] pathParents;
    public GameObject parentObject;  
    public int pathId = 0;
     Vector3[][] paths;
     int currentPointIndex = 0;
     bool isMoving = false;

    public int collectedCount = 0;
    public float speed = 5.0f;
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
        } 
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
         parentObject.transform.localPosition = new Vector3 (0,0,-1);
         PathCreate();
    }
    void Update()
    {
        Movement();     
    }

    void Movement()
    {
        if(!isGameEnd && !isDead)
        { 
             if (Input.GetKey(KeyCode.Space))
        {
            if (!isMoving)
            {
                isMoving = true;
                MoveToNextPoint();
            }
        }
        else
        {
            isMoving = false;
            transform.DOKill(); // Hareketi durdur
        }
        }
    }
     private void MoveToNextPoint()
    {
        if (currentPointIndex < paths[pathId].Length)
        {
            Vector3 nextPoint = paths[pathId][currentPointIndex];
            float distance = Vector3.Distance(transform.position, nextPoint);
            float duration = distance / speed;

            transform.DOMove(nextPoint, duration).SetEase(Ease.Linear).OnComplete(() =>
            {
                if (isMoving)
                {
                    currentPointIndex++;
                    MoveToNextPoint();
                }
            });
        }
    }
void PathCreate()
    {
        // Path noktalarını pathParents'ın child objelerinden al
        paths = new Vector3[pathParents.Length][];
        for (int i = 0; i < pathParents.Length; i++)
        {
            Transform[] pathTransforms = pathParents[i].GetComponentsInChildren<Transform>();
            paths[i] = new Vector3[pathTransforms.Length - 1];
            for (int j = 1; j < pathTransforms.Length; j++)
            {
                paths[i][j - 1] = pathTransforms[j].position; // İlk eleman pathParent olduğundan atlanır
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
                child.gameObject.transform.DOLocalMove(new Vector3(Random.Range(-6,6),1,Random.Range(-6,6)), 0.5f);
                Destroy(child.gameObject, Random.Range(0.1f,1.5f));
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
                other.transform.DOLocalJump(new Vector3(0, collectedCount, 0),0.5f,1,0.3f);        
                //other.transform.localPosition = new Vector3(0, collectedCount, 0);                    
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
                Debug.Log(totalMoney);
                NewLevelStart();
            }
        }
    }
    public void NewLevelStart()
    {
        LevelManager.instance.NewLevel();
        collectedCount = 0;
        totalMoney = 0;
        isDamaged = false;
        gameObject.transform.position = new Vector3(-1,0,0); 
    }
  
}