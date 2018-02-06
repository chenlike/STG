using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    //移动速度
    public float moveSpeed = 0f;
    //目前的旋转角度
    protected float nowAngle = 0f;



    void Start () {

	}
    // Update is called once per frame

    private void FixedUpdate()
    {
        MoveAhead();
    }

    /// <summary>
    /// 向前移动
    /// </summary>
    void MoveAhead()
    {
        if (moveSpeed == 0f ) return;
        transform.position += transform.up* moveSpeed*Time.deltaTime;
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
