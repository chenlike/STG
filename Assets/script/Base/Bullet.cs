using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Enemy {

    public delegate void BulletEvent(GameObject me);
    public BulletEvent OnDestoryEvent;
    public BulletEvent UpdateEvent;
    public BulletEvent  StartEvent;

    private void Start()
    {
        if(StartEvent!=null)
            StartEvent(this.gameObject);
    }
    private void Update()
    {
        if (UpdateEvent != null)
            UpdateEvent(this.gameObject);
        UpdateEvent = null;
        CheckDead();
    }

    private void CheckDead()
    {
        if ((transform.position.x >= 4 || transform.position.x <= -4)
    || (transform.position.y >= 5.5 || transform.position.y <= -5.5))
        {
            if (OnDestoryEvent != null)
                OnDestoryEvent(this.gameObject);
            Destroy(this.gameObject);
        }

    }


}
