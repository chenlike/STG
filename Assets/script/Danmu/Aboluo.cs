using UnityEngine;
using System.Collections;
using DanmuLib;
using System.Collections.Generic;

public class Aboluo : BulletShooter
{
    GameObject blueStar;
    GameObject laser;
    void InitRes()
    {

        blueStar = Resources.Load("Bullet/blueStar") as GameObject;
        laser = Resources.Load("Bullet/laser") as GameObject;
    }

    void TouchWall(GameObject target)
    {

        float angle = target.GetComponent<Enemy>().nowAngle;

        GameObject obj = DanmuLib.SingleDanmu.CreateSingleDanmu(laser, target.transform.position, 1.66f);
        Bullet blt = obj.GetComponent<Bullet>();
        blt.ChangeFaceAngle(-1*(angle));
        obj.SetActive(true);

    }

    IEnumerator ShootStar()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            List<GameObject> list = CircleDanmu.CreateCircleDanmu(blueStar, transform, 36, 1.66f);
            foreach (GameObject obj in list)
            {
                Bullet b = obj.GetComponent<Bullet>();
                b.OnDestoryEvent += TouchWall;
            }
            Shoot(list);
        }
    }

    // Use this for initialization
    void Start()
    {
        InitRes();
        StartCoroutine(ShootStar());
    }

    // Update is called once per frame
    void Update()
    {

    }



}
