using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Enemy {

    public delegate void BulletEvent(GameObject me);
    public delegate void TouchWall(GameObject me, GameObject touchObj);
    public TouchWall OnDestoryEvent;
    public BulletEvent UpdateEvent;
    public BulletEvent  StartEvent;
    public bool TouchDontDestory { get; set; }
    private void Start()
    {
        if (StartEvent != null)
        {
            Debug.Log("??");
            StartEvent(this.gameObject);
        }
    }
    private void Update()
    {
        if (UpdateEvent != null)
            UpdateEvent(this.gameObject);
        UpdateEvent = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (OnDestoryEvent != null)
            
            OnDestoryEvent(this.gameObject,collision.gameObject);
        if(!TouchDontDestory)
            Destroy(this.gameObject);
    }



}
