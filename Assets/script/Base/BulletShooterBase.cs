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
                yield return new WaitForSecondsRealtime(delayTime);
            obj.SetActive(true);
        }
    }
    public void Shoot(List<GameObject> list)
    {
        for(int i = 0; i < list.Count; i++)
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


    


}
