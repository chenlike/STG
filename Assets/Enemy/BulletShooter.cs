using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BulletShooter : Enemy
{

    List<GameObject> bulletPool = new List<GameObject>();

    IEnumerator CreateCircle()
    {
       // print(Time.time);
       for(int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(2);
            Vector3 a = new Vector3(0, 0, 0);
            CreateCircleBullet(6,transform.position, transform.rotation);
        }

    }


    protected override void DoStart()
    {
            StartCoroutine(CreateCircle());
    }
    protected override void DoUpdate()
    {

        
    }


    public void CreateCircleBullet(int num,Vector3 point, Quaternion rotation)
    {
        float angle = 0f;
        //GameObject bulletTemplate = Resources.Load("bul") as GameObject;

        /*
             for (; angle < 360f; angle += 360f / (float)num)
        {
            GameObject bullet = Instantiate(bulletTemplate,point, rotation);
            bullet.AddComponent<Bullet>();
            bullet.GetComponent<Bullet>().ChangeFaceAngle(angle);
            bullet.GetComponent<Bullet>().moveSpeed = 1f;
            bullet.GetComponent<Bullet>().isAlive = true; 
            bulletPool.Add(bullet);
        }    
         */
        int idx = 0; ;
        for (; angle < 360f; angle += 360f / (float)num)
        {
            string nname = "bul" + (idx == 0 ? "" : idx.ToString());
            GameObject bulletTemplate = Resources.Load(nname) as GameObject;
            GameObject bullet = Instantiate(bulletTemplate, point, Quaternion.identity);
            bullet.transform.position = point;
            bullet.AddComponent<Bullet>();
            bullet.GetComponent<Bullet>().ChangeFaceAngle(angle);
            bullet.GetComponent<Bullet>().moveSpeed = 1f;
            bullet.GetComponent<Bullet>().isAlive = true;
            bulletPool.Add(bullet);
            idx++;
        }


    }
}