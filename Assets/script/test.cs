using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanmuLib;
public class test : BulletShooter {
    GameObject tem;
    
    IEnumerator DanmuShootLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            List<GameObject> fireList = CircleDanmu.CreateCircle(tem, this.transform, 8, 1.66f);
            Shoot(fireList);
        }

    }
    private void Start()
    {
        tem = Resources.Load("bul1") as GameObject;
        StartCoroutine(DanmuShootLoop());
    }
}
