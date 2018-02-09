using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DanmuLib;
public class Doremi : BulletShooter {
    Dictionary<string, GameObject> dm = new Dictionary<string, GameObject>();
    string[] arrPic = new string[9];
    GameObject player;
    
    IEnumerator ShootCar()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            GetComponentInParent<CharacterAni>().SetMove(3);
            float speed = 2.5f;
            float speedStep = 0.2f;
            float moveStep = 0.2f;

            Vector3 pos = new Vector3(transform.position.x-1f, transform.position.y, transform.position.z);
            List<GameObject> mainList = 
                DanmuLib.FocusDanmu.CreateMultiDanmu(dm["greenArrow"], new Vector3(pos.x+moveStep*5,pos.y,pos.z),player.transform.position,10,speed+speedStep*5);
            foreach(GameObject obj in mainList)
            {
                obj.transform.parent = this.gameObject.transform;
            }
           
            Vector3 angle = mainList[0].transform.eulerAngles;
            List<GameObject>[] arrowList= new List<GameObject>[9];
            arrowList[4] = mainList;

            float changeSpeed = 1;
            for(int i = 0; i < 9; i++)
            {
                pos.x += moveStep;             
                speed += speedStep * changeSpeed;
                if (i == 4)
                {
                    changeSpeed = -1;

                    continue;
                }
                arrowList[i] = DanmuLib.FocusDanmu.CreateMultiDanmu(dm[arrPic[i]], pos, player.transform.position, 10, speed);
                foreach (GameObject bb in arrowList[i])
                {
                    bb.transform.parent = this.gameObject.transform;
                    bb.transform.eulerAngles = angle;
                }
            }


            for (int i = 0; i < 9; i++)
            {
                foreach(GameObject obj in arrowList[i])
                {
                    obj.transform.parent = null;
                }
                Shoot(arrowList[i], 0.07f);

            }



        }
    }
    IEnumerator ShootCircle()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);
            List<GameObject> fireList = CircleDanmu.CreateCircleDanmu(dm["redBall"], transform.position, 36, 1.06f);
            Shoot(fireList);
        }

    }
    private void InitRes()
    {


        dm["redBall"] = Resources.Load("Bullet/redBall") as GameObject;

        dm["greenArrow"] = Resources.Load("Bullet/greenArrow") as GameObject;
        dm["blueArrow"] = Resources.Load("Bullet/blueArrow") as GameObject;
        dm["blueArrowLow"] = Resources.Load("Bullet/blueArrowLow") as GameObject;
        dm["pupArrow"] = Resources.Load("Bullet/pupArrow") as GameObject;
        dm["pupArrowLow"] = Resources.Load("Bullet/pupArrowLow") as GameObject;
        dm["redArrow"] = Resources.Load("Bullet/redArrow") as GameObject;
        dm["redArrowLow"] = Resources.Load("Bullet/redArrowLow") as GameObject;
        dm["yellowArrow"] = Resources.Load("Bullet/yellowArrow") as GameObject;
        dm["yellowArrowLow"] = Resources.Load("Bullet/yellowArrowLow") as GameObject;
        arrPic[0] = "pupArrowLow";
        arrPic[1] = "pupArrow";
        arrPic[2] = "blueArrow";
        arrPic[3] = "blueArrowLow";
        arrPic[4] = "greenArrow";
        arrPic[5] = "redArrowLow";
        arrPic[6] = "yellowArrowLow";
        arrPic[7] = "yellowArrow";
        arrPic[8] = "redArrow";
    }
    private void Start()
    {
        player = GameObject.Find("player(Clone)");

        InitRes();
        StartCoroutine(ShootCircle());
        StartCoroutine(ShootCar());
    }
    private void Update()
    {


    }

}
