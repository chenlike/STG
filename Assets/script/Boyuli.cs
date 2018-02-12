using UnityEngine;
using System.Collections;
using Utils;
using System.Collections.Generic;
using UnityEngine.UI;
using Assets.script.Interface;

public class Boyuli : BulletShooterBase, IBulletShooter
{
    GameObject tem;

    public void PrePare()
    {
        tem = Resources.Load("Bullet/pinkMi") as GameObject;
        updateEvent += ro;
    }

    public void StartShoot()
    {
        StartCoroutine(danmu());
    }
    void ro(GameObject self)
    {
        RotateLoop(1.5f);
    }

    IEnumerator danmu()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.04f);
            var list = CircleDanmu.CreateCircleDanmu(tem, this.transform, 20, 0.02f);
            TransformUtils.PushObjLength(list, 0.5f);
            Shoot(list);
        }

    }

}
