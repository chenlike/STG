using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanmuLib;
public class Doremi : BulletShooter {
    GameObject tem;
    Animator ator;
    public void rreset()
    {
        ator.SetInteger("move", 0);
    }
    IEnumerator DanmuShootLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            List<GameObject> fireList = CircleDanmu.CreateCircle(tem, this.transform, 36, 1.66f);
            Shoot(fireList);
            ator.SetInteger("move", 3);
        }

    }
    private void Start()
    {
        ator = GetComponent<Animator>();
        tem = Resources.Load("bullet/RedBall") as GameObject;
        StartCoroutine(DanmuShootLoop());
    }
}
