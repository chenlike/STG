using UnityEngine;
using System.Collections;
using Base;

public class Bullet : Enemy,IObjectPool
{
    /// <summary>
    /// 所有者
    /// </summary>
    public string owner { get; set; }
    /// <summary>
    /// 是否触碰墙壁调用touchWallEvent
    /// </summary>
    bool isTouchWallDead = true;
    public float destoryDelayTime { get; set; }
    /// <summary>
    /// TouchEvent
    /// </summary>
    /// <param name="obj">自身</param>
    /// <param name="touchObj">触碰者</param>
    public delegate void TouchEvent(GameObject obj, GameObject touchObj);
    public TouchEvent touchEvent;


    public void SetDefault()
    {
        SetDisable();
        owner = null;
        startEvent = null;
        touchEvent = null;
        updateEvent = FlyForward;
    }


    private void OnBecameInvisible()
    {
        DestroyMe(destoryDelayTime);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (isTouchWallDead)
        {
            touchEvent?.Invoke(this.gameObject, collision.gameObject);
        }
    }
}
