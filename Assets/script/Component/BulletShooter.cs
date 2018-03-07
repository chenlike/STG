using System;
using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;

public class BulletShooter:Enemy,IObjectPool
{
    private IEnumerator DelayShoot(List<Bullet> list, float delayTime)
    {
        foreach (Bullet obj in list)
        {
            if (delayTime != 0)
                yield return new WaitForSeconds(delayTime);
            obj.SetEnable();
        }
    }
    private IEnumerator DelayShootList(List< List<Bullet>> list,float listDelayTime, float bulletDelayTime)
    {
        foreach (var obj in list)
        {
            if(listDelayTime!=0)
                yield return new WaitForSeconds(listDelayTime);
            foreach(var o in obj)
            {
                if (bulletDelayTime != 0)
                    yield return new WaitForSeconds(bulletDelayTime);
                o.SetEnable();
            }
        }
    }
    public void Shoot(Bullet obj)
    {
        obj.SetEnable();
    }




    public void Shoot(List< List<Bullet>> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            for(int j = 0; j < list[i].Count; j++)
            {
                list[i][j].SetEnable();
            }
        }
    }
    public void Shoot(List<List<Bullet>> list,float listDelayTime=0f,float bulletDelayTime=0f)
    {
        StartCoroutine(DelayShootList(list,listDelayTime,bulletDelayTime));
    }
    public void Shoot(List<Bullet> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].SetEnable();
        }
    }
    /// <summary>
    /// 每个弹幕等待时间后发射
    /// </summary>
    /// <param name="list"></param>
    /// <param name="delayTime"></param>
    public void Shoot(List<Bullet> list, float delayTime)
    {
        StartCoroutine(DelayShoot(list, delayTime));
    }
    public void SetDefault()
    {
        flySpeed = 0f;
        SetDisable();
        startEvent = null;
        updateEvent = FlyForward;
    }
}

