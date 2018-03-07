using UnityEngine;
using System.Collections;
using Utils;
using System.Collections.Generic;

namespace Danmu
{
    /// <summary>
    /// 自机狙
    /// </summary>
    public class FocusDanmu
    {

        private static Bullet SingleFocusDanmu(GameObject template, Vector3 nowPosition, Vector3 target, float flySpeed)
        {
            GameObject bullet = DanmuUtils.InitTemplate(template, nowPosition);
            DanmuUtils.ChangeFocus(bullet, target);

            Bullet script = bullet.GetComponent<Bullet>();
            if (script == null)
                script = bullet.AddComponent<Bullet>();
            script.SetDefault();
            bullet.GetComponent<Bullet>().flySpeed = flySpeed;

            bullet.transform.parent = null;
            return script;
        }

        /// <summary>
        /// 面向点飞行弹幕
        /// </summary>
        /// <param name="template">模板</param>
        /// <param name="nowPosition">起始位置</param>
        /// <param name="target">目标</param>
        /// <param name="flySpeed">速度</param>
        /// <returns></returns>
        public static Bullet CreateFocusPointDanmu(GameObject template, Vector3 nowPosition, Vector3 target, float flySpeed)
        {

            var obj = SingleFocusDanmu(template, nowPosition, target, flySpeed);

            return obj;
        }
        public static Bullet CreateFocusGameObjectDanmu(GameObject template, Vector3 nowPosition, GameObject target, float flySpeed)
        {
            return CreateFocusPointDanmu(template, nowPosition, target.transform.position, flySpeed);
        }

        /// <summary>
        /// 多个面向目标的弹幕
        /// </summary>
        /// <param name="template"></param>
        /// <param name="nowPosition"></param>
        /// <param name="target"></param>
        /// <param name="num"></param>
        /// <param name="flySpeed"></param>
        /// <returns></returns>
        public static List<Bullet> CreateMultiDanmu(GameObject template, Vector3 nowPosition, Vector3 target, int num, float flySpeed)
        {

            var danmuList = new List<Bullet>();
            if (num == 0)
                return danmuList;
            for (int i = 0; i < num; i++)
            {
                danmuList.Add(SingleFocusDanmu(template, nowPosition, target, flySpeed));
            }
            return danmuList;
        }
        public static List<Bullet> CreateMultiDanmu(GameObject template, Vector3 nowPosition, GameObject target, int num, float flySpeed)
        {
            return CreateMultiDanmu(template, nowPosition, target.transform.position, num, flySpeed);
        }

    }
}
