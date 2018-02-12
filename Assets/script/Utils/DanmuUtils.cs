using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Utils
{
    
    static class DanmuUtil
    {
        public static ObjectPool objPool = GameObject.Find("GameObjectPool").GetComponent<ObjectPool>();
        /// <summary>
        /// 按Transform实例化
        /// </summary>
        /// <param name="template"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static GameObject InitTemplate(GameObject template, Transform ts)
        {
            var getRes = objPool.FindGameObject(template.name);
            if (getRes == null)
            {
                GameObject obj =    Object.Instantiate(template, ts) as GameObject;
                obj.SetActive(false);
                obj.name = template.name;
                obj.transform.position = ts.position;
                return obj;
            }
            else
            {
                return getRes;
            }
            
        }
        /// <summary>
        /// 按坐标实例化
        /// </summary>
        /// <param name="template"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static GameObject InitTemplate(GameObject template, Vector3 position)
        {

            var getRes = objPool.FindGameObject(template.name);
            if (getRes == null)
            {
                GameObject obj = Object.Instantiate(template, position, Quaternion.identity);
                obj.SetActive(false);
                obj.name = template.name;
                obj.transform.position = position;
                return obj;
            }
            else
            {
                return getRes;
            }
        }
        /// <summary>
        /// 面向目标
        /// transform.eulerAngles = FocusToTarget(target,now)
        /// </summary>
        /// <param name="target">目标</param>
        /// <param name="now">自身</param>
        /// <returns></returns>
        public static Vector3 FocusToTarget(Vector3 target, Vector3 now)
        {
            Vector3 direction = target - now;
            float angle = 360 - Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            return new Vector3(0, 0, angle);
        }
        /// <summary>
        /// 改变GameObject朝向
        /// </summary>
        /// <param name="obj">本体</param>
        /// <param name="target">面向目标</param>
        public static void ChangeFocus(GameObject obj, Vector3 target)
        {
            obj.transform.eulerAngles = FocusToTarget(target, obj.transform.position);
        }

    }
    public class SingleDanmu
    {
        /// <summary>
        /// 创造单个弹幕
        /// </summary>
        /// <param name="bulletTemplate">模板</param>
        /// <param name="ts">父</param>
        /// <param name="angle">朝向</param>
        /// <param name="speed">速度</param>
        /// <param name="connectWithParent">是否与父级断开</param>
        /// <returns></returns>
        public static GameObject CreateSingleDanmu(GameObject bulletTemplate, Transform ts, float angle, float speed, bool connectWithParent)
        {
            GameObject obj = DanmuUtil.InitTemplate(bulletTemplate, ts.position);

            if (!connectWithParent)
                obj.transform.parent = null;
            if (obj.GetComponent<BulletBase>() == null)
                obj.AddComponent<BulletBase>();
            BulletBase bul = obj.GetComponent<BulletBase>();

            bul.speed = speed;
            TransformUtils.RotateFromZero(obj, angle);
            return obj;
        }

        public static GameObject CreateSingleDanmu(GameObject bulletTemplate, Vector3 pos, float speed)
        {
            GameObject obj = DanmuUtil.InitTemplate(bulletTemplate, pos);
            if (obj.GetComponent<BulletBase>() == null)
                obj.AddComponent<BulletBase>();
            BulletBase bul = obj.GetComponent<BulletBase>();

            bul.speed = speed;
            TransformUtils.RotateFromZero(obj, 0f);
            return obj;
        }
    }
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
        public static List<GameObject> CreateArcDanmu(GameObject bulletTemplate, Transform parent, float fromAngle,float endAngle,int num, float speed,bool connectWithParent)
        {
            List<GameObject> danmuList = new List<GameObject>();
            if (num == 0) return danmuList;

            float angle = fromAngle;

            for (; angle <= endAngle; angle += Mathf.Abs(endAngle-fromAngle) /num)
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
        public static List<GameObject> CreateArcDanmu(GameObject bulletTemplate,Vector3 pos,float fromAngle,float endAngle,int num,float speed)
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
            for (; angle <360f; angle += angleStep)
            {
                GameObject bullet = DanmuUtil.InitTemplate(bulletTemplate, parent);
                if(bullet.GetComponent<BulletBase>()==null)
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
            float angleStep = 360f /num;//36/2
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

