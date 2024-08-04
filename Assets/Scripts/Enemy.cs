using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Enemy : MonoBehaviour
{
    public float speed = 4.0f;

    void Start()
    { 
        transform.DOMoveX(12,speed).SetLoops(100,LoopType.Yoyo);
    }

}
