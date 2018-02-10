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
        SceneControl sc = GameObject.Find("Main Camera").GetComponent<SceneControl>();

        blueStar = sc.GetResByName("blueStar"); 
        laser = sc.GetResByName("greenArrow"); 
    }

    void TouchWall(GameObject target, GameObject touchObj)
    {

        float angle = target.transform.eulerAngles.z;

        GameObject obj = DanmuLib.SingleDanmu.CreateSingleDanmu(laser, target.transform.position, 1.66f);
        Bullet blt = obj.GetComponent<Bullet>();
        if (touchObj.name == "up" || touchObj.name == "down")
            blt.ChangeFaceAngle(angle + 180);
        else
            blt.ChangeFaceAngle(-1*(angle));


        obj.SetActive(true);

    }

    IEnumerator ShootStar()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            int ran = Random.Range(0, 5);
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            pos.x += ran*0.05f * ran % 2 == 0 ? 1 : -1;
            pos.y += ran*0.05f * ran % 2 == 0 ? -1 : 1;
            List<GameObject> list = CircleDanmu.CreateCircleDanmu(blueStar, pos, 36, 1.66f);
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
