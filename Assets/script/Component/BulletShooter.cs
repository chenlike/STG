using System;
using System.Collections;
using System.Collections.Generic;
using Base;
using UnityEngine;

public class BulletShooter:Enemy,IObjectPool
{
    private IEnumerator DelayShoot(List<GameObject> list, float delayTime)
    {
        foreach (GameObject obj in list)
        {
            if (delayTime != 0)
                yield return new WaitForSeconds(delayTime);
            obj.SetActive(true);
        }
    }
    private IEnumerator DelayShootList(List< List<GameObject>> list,float listDelayTime, float bulletDelayTime)
    {
        foreach (var obj in list)
        {
            if(listDelayTime!=0)
                yield return new WaitForSeconds(listDelayTime);
            foreach(var o in obj)
            {
                if (bulletDelayTime != 0)
                    yield return new WaitForSeconds(bulletDelayTime);
                o.SetActive(true);
            }
        }
    }
    public void Shoot(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void Shoot(List< List<GameObject>> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            for(int j = 0; j < list[i].Count; j++)
            {
                list[i][j].SetActive(true);
            }
        }
    }
    public void Shoot(List<List<GameObject>> list,float listDelayTime=0f,float bulletDelayTime=0f)
    {
        StartCoroutine(DelayShootList(list,listDelayTime,bulletDelayTime));
    }
    public void Shoot(List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].SetActive(true);
        }
    }
    /// <summary>
    /// 每个弹幕等待时间后发射
    /// </summary>
    /// <param name="list"></param>
    /// <param name="delayTime"></param>
    public void Shoot(List<GameObject> list, float delayTime)
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

