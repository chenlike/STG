using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Danmu
{

    /// <summary>
    /// 圆形发散弹幕
    /// </summary>
    public class CircleDanmu
    {

        /*
             0
        90    270
           180
             */
        /// <summary>
        /// 弧形弹
        /// </summary>
        /// <param name="bulletTemplate">模板</param>
        /// <param name="parent">父</param>
        /// <param name="fromAngle">从那个角度开始</param>
        /// <param name="endAngle">到哪个角度结束</param>
        /// <param name="num">平均分多少个</param>
        /// <param name="flySpeed">速度</param>
        /// <param name="connectWithParent">是否与父断开</param>
        /// <returns></returns>
        public static List<GameObject> CreateArcDanmu(GameObject bulletTemplate, Transform parent, float fromAngle, float endAngle, int num, float flySpeed, bool connectWithParent)
        {
            List<GameObject> danmuList = new List<GameObject>();
            if (num == 0) return danmuList;

            float angle = fromAngle;

            for (; angle <= endAngle; angle += Mathf.Abs(endAngle - fromAngle) / num)
            {


                GameObject bullet = DanmuUtils.InitTemplate(bulletTemplate, parent);
                bullet.transform.position = parent.position;
                Bullet script = bullet.GetComponent<Bullet>();
                if (script == null)
                    script = bullet.AddComponent<Bullet>();
                script.SetDefault();

                DanmuUtils.ChangeFaceAngle(bullet,angle + parent.transform.eulerAngles.z);
                bullet.GetComponent<Bullet>().flySpeed = flySpeed;

                if (!connectWithParent)
                    bullet.transform.parent = null;
                danmuList.Add(bullet);

            }
            return danmuList;
        }

        public static List<GameObject> CreateArcDanmu(GameObject bulletTemplate, Vector3 pos, float fromAngle, float endAngle, int num, float flySpeed)
        {
            List<GameObject> danmuList = new List<GameObject>();
            if (num == 0) return danmuList;

            float angle = fromAngle;

            for (; angle <= endAngle; angle += (Mathf.Abs(endAngle - fromAngle) / num))
            {
                if (danmuList.Count == num) break;
                GameObject bullet = DanmuUtils.InitTemplate(bulletTemplate, pos);
                bullet.transform.position = pos;
                Bullet script = bullet.GetComponent<Bullet>();

                if (script == null)
                    script = bullet.AddComponent<Bullet>();
                script.SetDefault();

                DanmuUtils.ChangeFaceAngle(bullet,angle);
                bullet.GetComponent<Bullet>().flySpeed = flySpeed;
                danmuList.Add(bullet);
            }
            
            return danmuList;
        }
        public static List<GameObject> CreateArcDanmu(GameObject bulletTemplate, Transform parent, float fromAngle, float endAngle, int num, float flySpeed)
        {
            return CreateArcDanmu(bulletTemplate, parent, fromAngle, endAngle, num, flySpeed, false);
        }


        public static List<GameObject> CreateArcDanmuEmpty(GameObject bulletTemplate, Vector3 pos, float startAngle, float endAngle, int num, float flySpeed)
        {

            if (num == 0) return null;
            float _startAngle = endAngle;
            float _endAngle =  (startAngle + 360f);
            return CreateArcDanmu(bulletTemplate,pos,_startAngle,_endAngle,num,flySpeed);

        }


        /// <summary>
        /// 创建圆形弹幕
        /// </summary>
        /// <param name="bulletTemplate">弹幕原型</param>
        /// <param name="parent">从属的parent</param>
        /// <param name="num">分割的数量360/num</param>
        /// <param name="flySpeed">移动速度</param>
        /// <param name="connectWithParent">与parent的链接</param>
        /// <returns></returns>
        public static List<GameObject> CreateCircleDanmu(GameObject bulletTemplate, Transform parent, int num, float flySpeed, bool connectWithParent)
        {
            List<GameObject> danmuList = new List<GameObject>();
            if (num == 0) return danmuList;

            float angle = 0f;
            float angleStep = 360f / num;
            for (; angle < 360f; angle += angleStep)
            {
                GameObject bullet = DanmuUtils.InitTemplate(bulletTemplate, parent);

                Bullet script = bullet.GetComponent<Bullet>();
                if (script == null)
                    script = bullet.AddComponent<Bullet>();
                script.SetDefault();

                DanmuUtils.ChangeFaceAngle(bullet,angle + parent.eulerAngles.z);
                bullet.GetComponent<Bullet>().flySpeed = flySpeed;
                bullet.transform.position = parent.position;
                if (!connectWithParent)
                    bullet.transform.parent = null;
                danmuList.Add(bullet);

            }
            return danmuList;
        }
        public static List<GameObject> CreateCircleDanmu(GameObject bulletTemplate, Transform parent, int num, float flySpeed)
        {
            return CreateCircleDanmu(bulletTemplate, parent, num, flySpeed, false);
        }
        public static List<GameObject> CreateCircleDanmu(GameObject bulletTemplate, Vector3 position, int num, float flySpeed)
        {
            List<GameObject> danmuList = new List<GameObject>();
            if (num == 0) return danmuList;

            float angle = 0f;
            float angleStep = 360f / num;//36/2
            for (; angle < 360f; angle += angleStep)
            {
                GameObject bullet = DanmuUtils.InitTemplate(bulletTemplate, position);
                bullet.transform.position = position;
                Bullet script = bullet.GetComponent<Bullet>();
                if (script == null)
                    script = bullet.AddComponent<Bullet>();
                script.SetDefault();
                DanmuUtils.ChangeFaceAngle(bullet,angle);
                script.flySpeed = flySpeed;
                bullet.transform.parent = null;
                danmuList.Add(bullet);

            }
            return danmuList;
        }
    }
}