using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Utils
{
    /// <summary>
    /// 自机狙
    /// </summary>
    public class FocusDanmu
    {

        private static GameObject SingleFocusDanmu(GameObject template, Vector3 nowPosition, Vector3 target, float speed)
        {
            GameObject obj = DanmuUtil.InitTemplate(template, nowPosition);
            DanmuUtil.ChangeFocus(obj, target);
            if (obj.GetComponent<BulletBase>() == null)
                obj.AddComponent<BulletBase>();
            obj.GetComponent<BulletBase>().speed = speed;

            obj.transform.parent = null;
            return obj;
        }

        /// <summary>
        /// 面向点飞行弹幕
        /// </summary>
        /// <param name="template">模板</param>
        /// <param name="nowPosition">起始位置</param>
        /// <param name="target">目标</param>
        /// <param name="speed">速度</param>
        /// <returns></returns>
        public static List<GameObject> CreateFocusPointDanmu(GameObject template, Vector3 nowPosition, Vector3 target, float speed)
        {
            List<GameObject> danmuList = new List<GameObject>();
            GameObject obj = SingleFocusDanmu(template, nowPosition, target, speed);
            danmuList.Add(obj);
            return danmuList;
        }
        public static List<GameObject> CreateFocusGameObjectDanmu(GameObject template, Vector3 nowPosition, GameObject target, float speed)
        {
            return CreateFocusPointDanmu(template, nowPosition, target.transform.position, speed);
        }

        /// <summary>
        /// 多个面向目标的弹幕
        /// </summary>
        /// <param name="template"></param>
        /// <param name="nowPosition"></param>
        /// <param name="target"></param>
        /// <param name="num"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        public static List<GameObject> CreateMultiDanmu(GameObject template, Vector3 nowPosition, Vector3 target, int num, float speed)
        {

            List<GameObject> danmuList = new List<GameObject>();
            if (num == 0)
                return danmuList;
            for (int i = 0; i < num; i++)
            {
                danmuList.Add(SingleFocusDanmu(template, nowPosition, target, speed));
            }
            return danmuList;
        }
        public static List<GameObject> CreateMultiDanmu(GameObject template, Vector3 nowPosition, GameObject target, int num, float speed)
        {
            return CreateMultiDanmu(template, nowPosition, target.transform.position, num, speed);
        }

    }
}