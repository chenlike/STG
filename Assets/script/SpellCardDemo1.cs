using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 妖怪测谎仪
/// </summary>
public class SpellCardDemo1 : SpellCardBase
{

    GameObject[] bullet = new GameObject[2];
    //弹幕发射器
    GameObject shooter;
    /// <summary>
    /// 加载资源
    /// </summary>
    private void InitRes()
    {
        bullet[0] = Utils.DanmuUtil.sceneControl.GetResByName("redMi");
        bullet[1] = Utils.DanmuUtil.sceneControl.GetResByName("blueMi");
    }
    /// <summary>
    /// 旋转向量公式
    /// </summary>
    /// <param name="v"></param>
    /// <param name="angle"></param>
    /// <returns></returns>
    private Vector3 RotationMatrix(Vector3 v, float angle)
    {
        var x = v.x;
        var y = v.y;
        var sin = Mathf.Sin(Mathf.PI * angle / 180);
        var cos = Mathf.Cos(Mathf.PI * angle / 180);
        var newX = x * cos + y * sin;
        var newY = x * -sin + y * cos;
        return new Vector3((float)newX, (float)newY,0f);
    }
    /// <summary>
    /// 发射bullet
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    IEnumerator Bullet(GameObject obj)
    {
        GameObject chy = GameObject.Find("cehuangyi") as GameObject;
        GameObject player = GameObject.Find("player") as GameObject;

        while (true)
        {
            Vector3 pPos = player.transform.position;
            yield return new WaitForSecondsRealtime(0.05f);
            //计算出player与圆心的距离得出向量
            float length = Mathf.Sqrt(pPos.x * pPos.x + pPos.y * pPos.y);
            Vector3 pos = new Vector3(0, length, 0);

            //当前测谎仪旋转角
            float addAngle = 360f - chy.transform.eulerAngles.z;

            for (int i = 0; i < 8; i++)
            {
                int tem = i % 2 != 0 ? 1 : 0;
                Vector3 tempPos = RotationMatrix(pos, addAngle + i * 45);
                GameObject b = Utils.SingleDanmu.CreateSingleDanmu(bullet[tem], new Vector3(tempPos.x, tempPos.y, 0f), 0f);
                BulletBase bulletBase = b.GetComponent<BulletBase>();
                bulletBase.ChangeFace(addAngle + i * 45 + i % 2 != 0 ? -90f : 0f);
                bulletBase.triggerEvent += BulletTouchEvent;
                bulletBase.message["bullet"] = tem.ToString();
                b.SetActive(true);

            }
        }


    }
    void StartShoot(GameObject obj)
    {
        obj.GetComponent<BulletShooterBase>().StartCoroutine(Bullet(obj));
    }
    /// <summary>
    /// 旋转
    /// </summary>
    /// <param name="obj"></param>
    void RotateChy(GameObject obj)
    {
        obj.transform.Rotate(Vector3.forward * 1f);
    }
    /// <summary>
    /// 判断是否碰撞到之前创造的bullet
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="touch"></param>
    void BulletTouchEvent(GameObject obj,GameObject touch)
    {
        string idx = obj.GetComponent<BulletBase>().message["bullet"];
        string tags = touch.tag.Substring(touch.tag.Length-1);
        if(tags != idx)
        {
            obj.GetComponent<BulletBase>().AddToPool();
        }
    }


    GameObject chyClone;
    public override void Prepare()
    {
        InitRes();
        shooter = CreateEmptyBulletShooter();
        shooter.GetComponent<BulletShooterBase>().startEvent += StartShoot;
        GameObject chy = Utils.DanmuUtil.sceneControl.GetResByName("cehuangyi");
        chyClone =  Utils.SingleDanmu.CreateSingleDanmu(chy, new Vector3(0, 0, 0), 0f);
        EnemyBase chyEmy = chyClone.AddComponent<EnemyBase>();
        chyEmy.updateEvent += RotateChy;
    }

    public override void Spell()
    {
        shooter.SetActive(true);
        chyClone.SetActive(true);
    }
    public override void StopSpell()
    {
        Object.Destroy(shooter);
        Object.Destroy(GameObject.Find("cehuangyi") as GameObject);
        foreach(var i in GameObject.FindGameObjectsWithTag("EnemyBullet"))
        {
            Object.Destroy(i);
        }

    }



}
