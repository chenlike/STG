using UnityEngine;
using System.Collections;
using PublicObj;
using System.Collections.Generic;

namespace Utils
{
    /// <summary>
    /// 弹幕工具
    /// </summary>
    static class DanmuUtils
    {

        /// <summary>
        /// 按Transform实例化
        /// </summary>
        /// <param name="template"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static GameObject InitTemplate(GameObject template, Transform ts)
        {
            var getRes =ObjectPool.GetGameObject(template.name);

            if (getRes == null)
            {
                GameObject obj = Object.Instantiate(template, ts) as GameObject;
                obj.SetActive(false);
                obj.name = template.name;
                obj.tag = "EnemyBullet";
                obj.transform.position = ts.position;
                return obj;
            }
            else
            {
                getRes.tag = "EnemyBullet";
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

            var getRes = ObjectPool.GetGameObject(template.name);

            if (getRes == null)
            {
                GameObject obj = Object.Instantiate(template, position, Quaternion.identity);
                obj.SetActive(false);
                obj.name = template.name;
                obj.tag = "EnemyBullet";
                obj.transform.position = position;
                return obj;
            }
            else
            {
                getRes.tag = "EnemyBullet";
                getRes.transform.position = position;
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
        public static void ChangeFocus(List<GameObject> list, Vector3 target)
        {
            list.ForEach(obj =>
            {
                ChangeFocus(obj,target);
            });
        }
        /// <summary>
        /// 让弹幕在当前位置和朝向向前移动一段距离
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="len"></param>
        public static void PushObjLength(GameObject obj, float len)
        {
            obj.transform.position += obj.transform.up * len;
        }
        public static void PushObjLength(List<GameObject> objList, float len)
        {
            objList.ForEach(obj => PushObjLength(obj, len));
        }
        /// <summary>
        /// 转换面朝角度
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="angle"></param>
        public static void ChangeFaceAngle(GameObject obj,float angle)
        {
            obj.transform.eulerAngles = new Vector3(0, 0, angle);
        }
        /// <summary>
        /// 更换弹幕外观
        /// </summary>
        /// <param name="before">要被更换的obj</param>
        /// <param name="after">新样子</param>
        public static void ReplaceTemplate(GameObject before, SpriteRenderer after)
        {
            before.GetComponent<SpriteRenderer>().sprite = after.sprite;
            before.name = after.gameObject.name;
        }
        public static void ReplaceTemplate(GameObject before, GameObject after)
        {
            ReplaceTemplate(before, after.GetComponent<SpriteRenderer>());
        }
        public static void ReplaceTemplate(List<GameObject> before, GameObject after)
        {
            before.ForEach(obj =>
            {
                ReplaceTemplate(obj, after.GetComponent<SpriteRenderer>());
            });
        }
        public static void ReplaceTemplate(List<GameObject> before, SpriteRenderer after)
        {
            before.ForEach(obj =>
            {
                ReplaceTemplate(obj, after);
            });
        }

        


    }
}

