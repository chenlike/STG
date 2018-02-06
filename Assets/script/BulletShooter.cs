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

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

}