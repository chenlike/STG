﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Utils
{
    
    static class DanmuUtil
    {
        public static ObjectPool objPool = GameObject.Find("GameObjectPool").GetComponent<ObjectPool>();
        public static SceneControl sceneControl = GameObject.Find("Main Camera").GetComponent<SceneControl>();


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

    }

}

