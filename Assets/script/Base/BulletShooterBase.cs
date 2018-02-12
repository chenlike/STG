using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletShooterBase : EnemyBase
{

    private IEnumerator DelayShoot(List<GameObject> list, float delayTime)
    {
        foreach (GameObject obj in list)
        {
            if(delayTime!=0)
                yield return new WaitForSeconds(delayTime);
            obj.SetActive(true);
        }
    }
    protected void Shoot(List<GameObject> list)
    {
        foreach (GameObject obj in list)
        {
            obj.SetActive(true);
        }
    }
    /// <summary>
    /// 每个弹幕等待时间后发射
    /// </summary>
    /// <param name="list"></param>
    /// <param name="delayTime"></param>
    protected void Shoot(List<GameObject> list, float delayTime)
    {
        StartCoroutine(DelayShoot(list, delayTime));
        
    }


}
