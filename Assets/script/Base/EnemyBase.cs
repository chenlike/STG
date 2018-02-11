using UnityEngine;
using System.Collections;
using Utils;
public class EnemyBase : MonoBehaviour
{

    protected delegate void StatusEvent(GameObject necessary);


    /// <summary>
    /// 当将要被销毁的
    /// </summary>
    protected StatusEvent destroyEvent;
    /// <summary>
    /// 当有物体碰撞时
    /// </summary>
    protected StatusEvent triggerEvent;
    /// <summary>
    /// 刚Start时
    /// </summary>
    protected StatusEvent startEvent;
    /// <summary>
    /// 每一帧调用
    /// </summary>
    protected StatusEvent updateEvent;
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
    protected void RotateLoop(float speed)
    {
        this.transform.Rotate(Vector3.forward * speed);
    }


    void Start()
    {


        if (startEvent!=null)
            startEvent(this.gameObject);
    }
    void Update()
    {
        if (updateEvent != null)
            updateEvent(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(triggerEvent!=null)
            triggerEvent(collision.gameObject);
        //碰到4个墙壁销毁
        
        if (collision.gameObject.transform.parent != null && collision.gameObject.transform.parent.gameObject.name == "Wall")
        {

            DanmuUtil.objPool.AddToPool(this.gameObject);
            Destroy(this);
        }
    }





}
