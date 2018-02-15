using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Utils
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
        /// <param name="speed">速度</param>
        /// <param name="connectWithParent">是否与父断开</param>
        /// <returns></returns>
        public static List<GameObject> CreateArcDanmu(GameObject bulletTemplate, Transform parent, float fromAngle, float endAngle, int num, float speed, bool connectWithParent)
        {
            List<GameObject> danmuList = new List<GameObject>();
            if (num == 0) return danmuList;

            float angle = fromAngle;

            for (; angle <= endAngle; angle += Mathf.Abs(endAngle - fromAngle) / num)
            {


                GameObject bullet = DanmuUtil.InitTemplate(bulletTemplate, parent);
                bullet.transform.position = parent.position;
                if (bullet.GetComponent<BulletBase>() == null)
                    bullet.AddComponent<BulletBase>();

                //parent.rotation.z范围是 -1<z<1  所以*=100
                //TransformUtils.RotateFromZero(bullet, angle + parent.rotation.z * 100);
                bullet.GetComponent<BulletBase>().ChangeFace(angle + parent.rotation.z * 100);
                bullet.GetComponent<BulletBase>().speed = speed;

                if (!connectWithParent)
                    bullet.transform.parent = null;
                danmuList.Add(bullet);

            }
            return danmuList;
        }
        public static List<GameObject> CreateArcDanmu(GameObject bulletTemplate, Vector3 pos, float fromAngle, float endAngle, int num, float speed)
        {
            List<GameObject> danmuList = new List<GameObject>();
            if (num == 0) return danmuList;

            float angle = fromAngle;

            for (; angle <= endAngle; angle += Mathf.Abs(endAngle - fromAngle) / (float)num)
            {

                GameObject bullet = DanmuUtil.InitTemplate(bulletTemplate, pos);
                bullet.transform.position = pos;
                if (bullet.GetComponent<BulletBase>() == null)
                    bullet.AddComponent<BulletBase>();
                bullet.GetComponent<BulletBase>().ChangeFace(angle);
                bullet.GetComponent<BulletBase>().speed = speed;
                danmuList.Add(bullet);
            }
            return danmuList;
        }


        /// <summary>
        /// 创建圆形弹幕
        /// </summary>
        /// <param name="bulletTemplate">弹幕原型</param>
        /// <param name="parent">从属的parent</param>
        /// <param name="num">分割的数量360/num</param>
        /// <param name="speed">移动速度</param>
        /// <param name="connectWithParent">与parent的链接</param>
        /// <returns></returns>
        public static List<GameObject> CreateCircleDanmu(GameObject bulletTemplate, Transform parent, int num, float speed, bool connectWithParent)
        {
            List<GameObject> danmuList = new List<GameObject>();
            if (num == 0) return danmuList;

            float angle = 0f;
            float angleStep = 360f / num;
            for (; angle < 360f; angle += angleStep)
            {
                GameObject bullet = DanmuUtil.InitTemplate(bulletTemplate, parent);
                if (bullet.GetComponent<BulletBase>() == null)
                    bullet.AddComponent<BulletBase>();

                bullet.GetComponent<BulletBase>().ChangeFace(angle + parent.rotation.z * 100.0f);
                bullet.GetComponent<BulletBase>().speed = speed;
                bullet.transform.position = parent.position;
                if (!connectWithParent)
                    bullet.transform.parent = null;
                danmuList.Add(bullet);

            }
            return danmuList;
        }
        public static List<GameObject> CreateCircleDanmu(GameObject bulletTemplate, Transform parent, int num, float speed)
        {
            return CreateCircleDanmu(bulletTemplate, parent, num, speed, false);
        }
        public static List<GameObject> CreateCircleDanmu(GameObject bulletTemplate, Vector3 position, int num, float speed)
        {
            List<GameObject> danmuList = new List<GameObject>();
            if (num == 0) return danmuList;

            float angle = 0f;
            float angleStep = 360f / num;//36/2
            for (; angle < 360f; angle += angleStep)
            {
                GameObject bullet = DanmuUtil.InitTemplate(bulletTemplate, position);
                bullet.transform.position = position;
                if (bullet.GetComponent<BulletBase>() == null)
                    bullet.AddComponent<BulletBase>();
                bullet.GetComponent<BulletBase>().ChangeFace(angle);
                bullet.GetComponent<BulletBase>().speed = speed;

                bullet.transform.parent = null;
                danmuList.Add(bullet);

            }
            return danmuList;
        }
    }
}