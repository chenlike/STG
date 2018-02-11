using UnityEngine;
using System.Collections;
using Utils;
using System.Collections.Generic;

public class Boyuli : BulletShooterBase
{
    GameObject tem;


    IEnumerator danmu()
    {
        while (true)
        {

                yield return new WaitForSeconds(0.08f);
                var list = CircleDanmu.CreateCircleDanmu(tem, this.transform, 21, 0.02f);
                Shoot(list);

        }

    }
    
    private void Start()
    {
        tem = Resources.Load("Bullet/pinkMi") as GameObject;
        StartCoroutine(danmu());

    }

    private void Update()
    {
        RotateLoop(1.5f);
    }
}
