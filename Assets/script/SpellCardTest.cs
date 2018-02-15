using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCardTest : BulletShooterBase {


    List<GameObject> temList = new List<GameObject>();
	void Start () {
        GameObject tem1 = Resources.Load("Bullet/redCard") as GameObject;
        GameObject tem2 = Resources.Load("Bullet/blueCard") as GameObject;
        GameObject tem3 = Resources.Load("Bullet/greenCard") as GameObject;
        temList.Add(tem1);
        temList.Add(tem2);
        temList.Add(tem3);
    }
    List<GameObject> list = new List<GameObject>();

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            targetPosition.z = 0;

            List<GameObject> a = Utils.CircleDanmu.CreateCircleDanmu(temList[Random.Range(0,3)], targetPosition, 36, 0.02f);
            Shoot(a);
        }



    }


}
