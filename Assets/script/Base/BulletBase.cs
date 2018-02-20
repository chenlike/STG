using UnityEngine;
using System.Collections;
using Utils;
public class BulletBase : EnemyBase
{
    
    public float speed = 0f;
    


    /// <summary>
    /// 向前移动
    /// </summary>
    private void MoveForward()
    {
        transform.position += transform.up * speed;
    }
    private void FixedUpdate()
    {
        MoveForward();
    }




}
