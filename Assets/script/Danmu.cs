using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

namespace DanmuLib
{
 
    public class CircleDanmu
    {

        private static GameObject InitTemplate(GameObject template,Transform ts)
        {
            return Object.Instantiate(template, ts);
        }
        private static GameObject InitTemplate(GameObject template, Vector3 position)
        {
            return Object.Instantiate(template, position,Quaternion.identity);
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
        public static List<GameObject> CreateCircle(GameObject bulletTemplate, Transform parent, int num,float speed,bool connectWithParent)
        {
            List<GameObject> danmuList = new List<GameObject>();
            if (num == 0) return danmuList;

            float angle = 0f;

            for (; angle < 360f; angle += 360f / (float)num)
            {

                GameObject bullet = InitTemplate(bulletTemplate, parent);
                bullet.SetActive(false);
                bullet.transform.position = parent.position;
                bullet.AddComponent<Bullet>();
                bullet.GetComponent<Bullet>().ChangeFaceAngle(angle);
                bullet.GetComponent<Bullet>().moveSpeed = speed;
                if(!connectWithParent)
                    bullet.transform.parent = null;
                danmuList.Add(bullet);

            }
            return danmuList;
        }
        public static List<GameObject> CreateCircle(GameObject bulletTemplate, Transform parent,int num,float speed)
        {
            return CreateCircle(bulletTemplate, parent, num, speed, false);
        }
        public static List<GameObject> CreateCircle(GameObject bulletTemplate, Vector3 position, int num, float speed)
        {
            List<GameObject> danmuList = new List<GameObject>();
            if (num == 0) return danmuList;

            float angle = 0f;

            for (; angle < 360f; angle += 360f / (float)num)
            {

                GameObject bullet = InitTemplate(bulletTemplate, position);
                bullet.SetActive(false);
                bullet.transform.position = position;
                bullet.AddComponent<Bullet>();
                bullet.GetComponent<Bullet>().ChangeFaceAngle(angle);
                bullet.GetComponent<Bullet>().moveSpeed = speed;
                bullet.transform.parent = null;
                danmuList.Add(bullet);

            }
            return danmuList;
        }
    }

}
