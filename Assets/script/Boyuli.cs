using UnityEngine;
using System.Collections;
using Utils;
using System.Collections.Generic;
using UnityEngine.UI;

public class Boyuli : BulletShooterBase
{
    GameObject tem;


    IEnumerator danmu()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.04f);
            var list = CircleDanmu.CreateCircleDanmu(tem, this.transform, 20, 0.04f);
            TransformUtils.PushObjLength(list, 0.5f);
            Shoot(list);
            
        }

    }
    IEnumerator danmu1()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            var list = CircleDanmu.CreateCircleDanmu(tem, this.transform, 36, 0.02f);

            TransformUtils.PushObjLength(list, 0.5f);
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
