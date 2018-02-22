using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Base
{
    public class GameObjectBase : MonoBehaviour
    {
        /// <summary>
        /// 用于记录信息
        /// </summary>
        public Dictionary<string, string> message = new Dictionary<string, string>();
        public delegate void StatusEvent(GameObject necessary);
        /// <summary>
        /// 刚Start时
        /// </summary>
        public StatusEvent startEvent;
        /// <summary>
        /// fixedUpdate调用
        /// </summary>
        public StatusEvent updateEvent;

        void Start()
        {
            startEvent?.Invoke(this.gameObject);
        }
        void FixedUpdate()
        {
            updateEvent?.Invoke(this.gameObject);
        }
        /// <summary>
        /// 获得当前启用状态
        /// </summary>
        /// <returns></returns>
        public bool GetStatus()
        {
            return isActiveAndEnabled;
        }
        /// <summary>
        /// 开始使用
        /// </summary>
        public void SetEnable()
        {
            this.gameObject.SetActive(true);
        }
        /// <summary>
        /// 停止使用
        /// </summary>
        public void SetDisable()
        {
            this.gameObject.SetActive(false);
        }
        /// <summary>
        /// 获得面向角度
        /// </summary>
        /// <returns></returns>
        public float GetAngle()
        {
            return transform.eulerAngles.z;
        }
    }

}
