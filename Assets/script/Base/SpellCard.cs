using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SpellCard
{
    /// <summary>
    /// 符卡名
    /// </summary>
    public string name { get; set; }
    /// <summary>
    /// 创建一个空的BulletShooter Gameobject
    /// </summary>
    /// <returns>false Active的GameObject</returns>
    protected GameObject CreateEmptyBulletShooter()
    {
        GameObject empty = new GameObject();
        empty.AddComponent<BulletShooterBase>();
        empty =  Object.Instantiate(empty);
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
        GameObject empty = new GameObject();
        empty.AddComponent<BulletShooterBase>();
        empty = Object.Instantiate(empty);
        empty.transform.position = pos;
        empty.SetActive(false);
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
