using UnityEngine;
using System.Collections;
using Base;
namespace Base
{
    public class Enemy : GameObjectBase
    {

        IEnumerator DelayDestoryEvent(float time)
        {
            yield return new WaitForSeconds(time);
            DestroyMe();
        }

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
        public void DestroyMe(float destoryDelayTime=0f)
        {

            if (destoryDelayTime != 0f)
            {
                StartCoroutine(DelayDestoryEvent(destoryDelayTime));
            }
            else
            {
                SetDisable();
                PublicObj.ObjectPool.AddToPool(this.gameObject);
            }

        }
    }

}
