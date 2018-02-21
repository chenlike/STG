using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellCardBase {

    /// <summary>
    /// 符卡的提前准备工作
    /// </summary>
    public abstract void Prepare();
    /// <summary>
    /// 开始施放符卡
    /// </summary>
    public abstract void Spell();
    /// <summary>
    /// 停止（结束）符卡
    /// </summary>
    public abstract void StopSpell();


    /// <summary>
    /// 符卡名
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 符卡持续时间
    /// </summary>
    public float spellKeepTime { get; set; }
    public float beforeSpellTime { get; set; }
    /// <summary>
    /// 创建一个空的BulletShooter Gameobject
    /// </summary>
    /// <returns>false Active的GameObject</returns>
    protected GameObject CreateEmptyBulletShooter()
    {
        GameObject empty = new GameObject();
        empty.tag = "EnemyBullet";
        empty.AddComponent<BulletShooterBase>();
        empty.transform.rotation = Quaternion.identity;
        empty.SetActive(false);
        return empty;
    }



    /// <summary>
    ///  按位置 创建一个空的BulletShooter Gameobject
    /// </summary>
    /// <param name="pos">坐标</param>
    /// <returns>false Active的GameObject</returns>
    protected GameObject CreateEmptyBulletShooter(Vector3 pos)
    {
        GameObject empty = CreateEmptyBulletShooter();
        empty.transform.position = pos;
        return empty;
    }

    /// <summary>
    /// 启动BulletShooter
    /// </summary>
    /// <param name="list"></param>
    protected void SetActiveList(List<GameObject> list)
    {
        list.ForEach(obj =>
        {
            obj.SetActive(true);
        });
    }



}
