using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BulletShooter : Enemy
{

    List<GameObject> bulletPool = new List<GameObject>();

    IEnumerator KeepShoot(int num,Transform ts)
    {
        // print(Time.time);
        int i = 0;
       for (i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.5f);

            CreateCircleBullet(i,ts);

        }

    }
    IEnumerator RotateSelf()
    {
        // print(Time.time);
        yield return new WaitForSeconds(2f);
        float angle = 0f;

        float sleepTime = 1f;
        while (true)
        {
            yield return new WaitForSeconds(sleepTime);

            ChangeFaceAngle(angle);
            angle -= 2f;
            if(sleepTime >= 0.0001)
            {
                sleepTime -= sleepTime/2f;
            }
            if (angle <= -360f) angle = 0;
        }
        

    }


    protected override void DoStart()
    {
        StartCoroutine(KeepShoot(1,this.transform));
        //StartCoroutine(RotateSelf());
    }

    protected override void DoUpdate()
    {

        
    }


    public void CreateCircleBullet(int num,Transform ts)
    {
        float angle = 0f;
        if (num == 0) return;
        GameObject bulletTemplate = Resources.Load("bul1") as GameObject;

        for (; angle < 360f; angle += 360f / (float)num)
        {
            GameObject bullet = Instantiate(bulletTemplate, ts);
            bullet.transform.position = ts.position;
            bullet.AddComponent<Bullet>();
            bullet.GetComponent<Bullet>().ChangeFaceAngle(angle+nowAngle);
            bullet.GetComponent<Bullet>().moveSpeed = 1.66f;
            bullet.GetComponent<Bullet>().isAlive = true;
            bullet.transform.parent = null;
            
      
        }


    }
}