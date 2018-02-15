using UnityEngine;
using System.Collections;
using Utils;
public class EnemyBase : MonoBehaviour
{

    public delegate void StatusEvent(GameObject necessary);


    /// <summary>
    /// 当将要被销毁的
    /// </summary>
    public StatusEvent destroyEvent;
    /// <summary>
    /// 当有物体碰撞时
    /// </summary>
    public StatusEvent triggerEvent;
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
    public Vector3 position;


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
        this.transform.Rotate(transform.forward * speed,Space.Self);
    }


    void Start()
    {
        startEvent?.Invoke(this.gameObject);
    }
    void Update()
    {
        updateEvent?.Invoke(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        triggerEvent?.Invoke(collision.gameObject);
        //碰到4个墙壁销毁

        if (collision.gameObject.transform.parent != null && collision.gameObject.transform.parent.gameObject.name == "Wall")
        {
            this.gameObject.SetActive(false);
            DanmuUtil.objPool.AddToPool(this.gameObject);
            Destroy(this);
        }
    }





}
