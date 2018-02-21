using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCardDemo : SpellCardBase
{
    //红玉
    GameObject redBall;
    //各种颜色的arrow
    GameObject[] arrows = new GameObject[9];

    //负责发射红玉的shooter
    GameObject circleShooter;
    //负责发射Arrows的shooter
    GameObject carShooter;
    //加载资源
    private void InitRes()
    {
        var res = Utils.DanmuUtil.sceneControl;
        redBall = res.GetResByName("redBall");
        arrows[0] = res.GetResByName("pupArrowLow");
        arrows[1] = res.GetResByName("pupArrow");
        arrows[2] = res.GetResByName("blueArrow");
        arrows[3] = res.GetResByName("blueArrowLow");
        arrows[4] = res.GetResByName("greenArrow");
        arrows[5] = res.GetResByName("yellowArrowLow");
        arrows[6] = res.GetResByName("yellowArrow");
        arrows[7] = res.GetResByName("redArrowLow");
        arrows[8] = res.GetResByName("redArrow");
    }
    /// <summary>
    /// 发射玉的循环
    /// </summary>
    /// <param name="obj">shooter</param>
    /// <returns></returns>
    IEnumerator CircleLoop(GameObject obj)
    {
        BulletShooterBase bsb = obj.GetComponent<BulletShooterBase>();
        while (true)
        {
            yield return new WaitForSecondsRealtime(1f);
            var list = Utils.CircleDanmu.CreateCircleDanmu(redBall, circleShooter.transform.position, 36, 0.06f);
            bsb.Shoot(list);
        }
    }
    /// <summary>
    /// 创造出Car 
    /// </summary>
    /// <param name="obj"></param>
    /// <returns>一个单独的GameObejct</returns>
    GameObject CreateList(GameObject obj)
    {
        GameObject a = new GameObject();
        a.SetActive(false);
        a.transform.position = obj.transform.position;
        a.transform.rotation = Quaternion.identity;

        GameObject player = GameObject.Find("player") as GameObject;
        BulletShooterBase bsb = obj.GetComponent<BulletShooterBase>();
        Vector3 arrowPos = bsb.transform.position;
        var list = new List<GameObject>();
        GameObject midArrow = Utils.FocusDanmu.CreateFocusGameObjectDanmu(arrows[4], obj.transform.position, player, 0.15f);
        float addedX = 0.2f;
        float speedStep = 0.01f;
        /*
         
         */
        //left
        for (int i = 0; i < 4; i++)
        {
            GameObject arrow =
                Utils.SingleDanmu.CreateSingleDanmu(
                    arrows[i], 
                    new Vector3(
                        arrowPos.x - addedX * (i + 1), arrowPos.y, 0), 
                  0.15f -  speedStep*(i+1));
            list.Add(arrow);
        }
        list.Add(midArrow);
        //right
        for (int i = 5; i < 9; i++)
        {
            GameObject arrow =
                Utils.SingleDanmu.CreateSingleDanmu(
                    arrows[i],
                    new Vector3(arrowPos.x + addedX * (i - 4),arrowPos.y, 0),
                    0.15f - speedStep * (i -4));
            list.Add(arrow);
        }
        Vector3 angle = midArrow.transform.eulerAngles;

        list.ForEach(arrow =>
        {
            arrow.transform.parent = a.transform;
            arrow.GetComponent<BulletBase>().ChangeFace(0f);
        });
        a.transform.eulerAngles = angle;
        a.tag = "EnemyBullet";
        a.name = "ArrowCar";
        list.ForEach(arrow =>
        {
            arrow.SetActive(true);
        });

        return a;
    }
    /// <summary>
    /// 发射car的循环
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    IEnumerator CircleCar(GameObject obj)
    {
        
        BulletShooterBase bsb = obj.GetComponent<BulletShooterBase>();
        while (true)
        {
            yield return new WaitForSecondsRealtime(3f);

            Vector3 arrowPos = obj.transform.position;
            bsb.transform.rotation = Quaternion.identity;
            var allList = new List<GameObject>();
            for(int i = 0; i <10; i++)
            {
                var c = CreateList(obj);
                allList.Add(c);
            }
            bsb.Shoot(allList, 0.08f);
            
        }
    }
    /// <summary>
    /// 启动
    /// </summary>
    /// <param name="obj"></param>
    private void SpellCircle(GameObject obj)
    {
        BulletShooterBase bsb =  obj.GetComponent<BulletShooterBase>();
        bsb.StartCoroutine(CircleLoop(obj));
    }
    private void SpellCar(GameObject obj)
    {
        BulletShooterBase bsb = obj.GetComponent<BulletShooterBase>();
        bsb.StartCoroutine(CircleCar(obj));
    }


    public override void Prepare()
    {
        spellKeepTime = 30f;
        InitRes();
        circleShooter = CreateEmptyBulletShooter(new Vector3(0,1,0));
        circleShooter.GetComponent<BulletShooterBase>().startEvent += SpellCircle;
        carShooter = CreateEmptyBulletShooter(new Vector3(0, 1, 0));
        carShooter.GetComponent<BulletShooterBase>().startEvent += SpellCar;
    }

    public override void Spell()
    {
        circleShooter.SetActive(true);
        carShooter.SetActive(true);
    }

    public override void StopSpell()
    {
        foreach (var i in GameObject.FindGameObjectsWithTag("EnemyBullet"))
        {
            Object.Destroy(i);
        }
    }

}
