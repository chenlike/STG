using UnityEngine;
using System.Collections;
using Base;
namespace Base
{
    public class Enemy : GameObjectBase
    {
        /// <summary>
        /// 向朝向的方向飞行的速度
        /// </summary>
        public float flySpeed = 0f;
        /// <summary>
        /// 向前飞
        /// </summary>
        /// <param name="obj"></param>
        protected void FlyForward(GameObject obj)
        {
            obj.transform.position += transform.up * flySpeed * 0.1f;
        }
        /// <summary>
        /// 销毁自己 加入对象池
        /// </summary>
        public void DestroyMe()
        {
            SetDisable();
            PublicObj.ObjectPool.AddToPool(this.gameObject);
        }
    }

}
