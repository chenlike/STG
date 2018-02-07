using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanmuLib;


public class BulletShooter : Enemy
{


    private IEnumerator RotateSelf(float angleStep, float totalSleepTime, float reduceTime, float limitMinTime)
    {

        float angle = 0f;

        float sleepTime = totalSleepTime;
        while (true)
        {
            yield return new WaitForSeconds(sleepTime);

            ChangeFaceAngle(angle);
            angle -= angleStep;
            if (sleepTime >= limitMinTime)
            {
                sleepTime -= reduceTime;
            }
        }
    }

    private IEnumerator DelayShoot(List<GameObject> list, float delayTime)
    {
        foreach(GameObject obj in list)
        {
            yield return new WaitForSeconds(delayTime);
            obj.SetActive(true);
        }
    }
    protected void StartRotate(float angleStep, float totalSleepTime, float reduceTime, float limitMinTime)
    {
        StartCoroutine(RotateSelf(angleStep, totalSleepTime, reduceTime, limitMinTime));
    }
    protected void StopRotate()
    {
        StopCoroutine("RotateSelf");
    }




    protected void Shoot(List<GameObject> list)
    {
        foreach (GameObject bullet in list)
        {
            bullet.SetActive(true);
        }
    }
    /// <summary>
    /// 每个弹幕等待时间后发射
    /// </summary>
    /// <param name="list"></param>
    /// <param name="delayTime"></param>
    protected void Shoot(List<GameObject> list,float delayTime)
    {
        StartCoroutine(DelayShoot(list,delayTime));
    }



    private void OnDestroy()
    {
        StopAllCoroutines();
    }

}