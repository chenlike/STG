using UnityEngine;
using System.Collections;
using Utils;
using System.Collections.Generic;

public class EnemyBase : MonoBehaviour
{
    public Dictionary<string, string> message = new Dictionary<string, string>();

    public delegate void StatusEvent(GameObject necessary);
    public delegate void touchEvent(GameObject obj,GameObject touch);

    /// <summary>
    /// 当将要被销毁的
    /// </summary>
    public StatusEvent destroyEvent;
    /// <summary>
    /// 当有物体碰撞时
    /// </summary>
    public touchEvent triggerEvent;
    /// <summary>
    /// 刚Start时
    /// </summary>
    public StatusEvent startEvent;
    /// <summary>
    /// 每一帧调用
    /// </summary>
    public StatusEvent updateEvent;
    protected float destroyTime = 0f;

    public float nowAngle = 0f;
    /// <summary>
    /// 修改朝向 (瞬时)
    /// </summary>
    /// <param name="angle"></param>
    public void ChangeFace(float angle)
    {
        transform.eulerAngles = new Vector3(0, 0, angle);// = new Quaternion(0, 0, angle,0);
        nowAngle = angle;
    }
    public void ResetScript()
    {
        destroyEvent = null;
        triggerEvent = null;
        startEvent = null;
        updateEvent = null;
        nowAngle = 0f;
        destroyTime = 0f;

         
    }
    protected void RotateLoop(float speed)
    {
        
        
        this.transform.Rotate(transform.forward * speed,Space.Self);
    }
    void Start()
    {
        startEvent?.Invoke(this.gameObject);
    }
    void FixedUpdate()
    {
        updateEvent?.Invoke(this.gameObject);
    }
    public void AddToPool()
    {
        this.gameObject.SetActive(false);
        DanmuUtil.objPool.AddToPool(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        triggerEvent?.Invoke(this.gameObject,collision.gameObject);
        //碰到4个墙壁销毁

        if (collision.gameObject.transform.parent != null && collision.gameObject.transform.parent.gameObject.name == "Wall")
        {
            AddToPool();
        }
    }





}
