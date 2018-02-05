using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public bool isAlive = false;
    //移动速度
    public float moveSpeed = 0f;
    //朝向的Vector位置
    protected Vector3 orientation;
    //目前的旋转角度
    protected float nowAngle = 0f;
    //旋转
    protected float rotateSpeed = 0f;
    protected float rotateAngle = 0f;

    

    protected virtual void DoUpdate()
    {

    }
    protected virtual void DoStart()
    {

    }

    void Start () {
        DoStart();
	}
    // Update is called once per frame
    void Update () {
        DoUpdate();
        if (isAlive)
        {
            MoveTowards();
        }

    }

    /*
             //Vector3 direction = orientation - transform.position;
        //float angle = 360 - Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        //transform.eulerAngles = new Vector3(0, 0, angle);
         
         */
    /// <summary>
    /// 向前移动
    /// </summary>
    void MoveTowards()
    {

        if (moveSpeed == 0f ) return;

        //Vector3 direction = orientation - transform.position;
        //float angle = 360 - Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        //transform.eulerAngles = new Vector3(0, 0, angle);
        transform.position += transform.up* moveSpeed * Time.deltaTime;
         
    }

    /// <summary>
    /// 更改朝向度数
    /// </summary>
    /// <param name="angle">角度</param>
    public void ChangeFaceAngle(float angle)
    {
        transform.rotation = Quaternion.Euler(0f, 0f, -1*angle);
        nowAngle = -1 * angle;
    }


}
