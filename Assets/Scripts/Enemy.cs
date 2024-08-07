using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy : MonoBehaviour
{
    void Start()
    { 
        float speed = Random.Range(1,4);
        transform.DOMoveZ(12,speed).SetLoops(-1,LoopType.Yoyo);
    }

}
