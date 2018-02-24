using Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDemo1 : SpellCard
{
    GameObject[] bullets = new GameObject[2];
    GameObject shooter;
    /// <summary>
    /// 加载资源
    /// </summary>
    private void InitRes()
    {
        bullets[0] = PublicObj.Template.GetTemplate("redMi");
        bullets[1] = PublicObj.Template.GetTemplate("blueMi");
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
        return new Vector3((float)newX, (float)newY, 0f);
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
            yield return new WaitForSecondsRealtime(0.1f);
            //计算出player与圆心的距离得出向量
            float length = Mathf.Sqrt(pPos.x * pPos.x + pPos.y * pPos.y);
            Vector3 pos = new Vector3(0, length, 0);

            //当前测谎仪旋转角
            float addAngle = 360f - chy.transform.eulerAngles.z;

            for (int i = 0; i < 8; i++)
            {
                int tem = i % 2 != 0 ? 1 : 0;
                Vector3 tempPos = RotationMatrix(pos, addAngle + i * 45);
                GameObject b =Danmu.SingleDanmu.CreateSingleDanmu(bullets[tem], new Vector3(tempPos.x, tempPos.y, 0f), addAngle + i * 45 + i % 2 != 0 ? -90f : 0f);
                Bullet bullet = b.GetComponent<Bullet>();

                bullet.touchEvent += BulletTouchEvent;
                bullet.message["bullet"] = tem.ToString();
                b.SetActive(true);

            }
        }


    }
    void StartShoot(GameObject obj)
    {
        obj.GetComponent<BulletShooter>().StartCoroutine(Bullet(obj));
    }
    /// <summary>
    /// 旋转
    /// </summary>
    /// <param name="obj"></param>
    void RotateChy(GameObject obj)
    {
        obj.transform.Rotate(Vector3.forward * 0.5f);
    }
    /// <summary>
    /// 判断是否碰撞到之前创造的bullet
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="touch"></param>
    void BulletTouchEvent(GameObject obj, GameObject touch)
    {
        string idx = obj.GetComponent<Bullet>().message["bullet"];
        string tags = touch.tag.Substring(touch.tag.Length - 1);
        
        if (tags == "Player") return;
        if (tags != idx)
        {
            obj.GetComponent<Bullet>().DestroyMe();
        }
    }
    public override void Prepare()
    {
        InitRes();

        shooter = CreateEmptyBulletShooter();
        shooter.GetComponent<BulletShooter>().startEvent += StartShoot;
        GameObject chy = Utils.DanmuUtils.InitTemplate(PublicObj.Template.GetTemplate("cehuangyi"), new Vector3(0, 0, 0));
        chy.SetActive(true);
        GameObjectBase chyEmy = chy.GetComponent<GameObjectBase>();
        chyEmy .updateEvent += RotateChy;
    }

    public override void Spell()
    {
        
        shooter.SetActive(true);
    }

    public override void StopSpell()
    {
        Object.Destroy(shooter);
        Object.Destroy(GameObject.Find("cehuangyi"));
    }
}
