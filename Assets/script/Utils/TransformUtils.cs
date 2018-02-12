using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class TransformUtils
    {



        /// <summary>
        /// 从当前角度开始旋转
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="angle"></param>
        /// <param name="time"></param>
        public static void RotateAngle(GameObject obj, float angle, float time)
        {
            iTween.RotateTo(obj, new Vector3(0, 0, angle), time);
        }
        public static void RotateAngle(GameObject obj, float angle)
        {
            RotateAngle(obj, angle, 0f);
        }
        public static void RotateAngle(List<GameObject> objList , float angle,float time)
        {
            objList.ForEach(obj => RotateAngle(obj, angle, time));
        }
        
        /// <summary>
        /// 归0后再开始旋转
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="angle"></param>
        /// <param name="time"></param>
        public static void RotateFromZero(GameObject obj, float angle, float time)
        {
            iTween.RotateTo(obj, new Vector3(0, 0, 0), 0);
            RotateAngle(obj, angle, time);
        }
        public static void RotateFromZero(GameObject obj, float angle)
        {
            iTween.RotateTo(obj, new Vector3(0, 0, 0), 0);
            RotateAngle(obj, angle, 0f);
        }
        public static void RotateFromZero(List<GameObject> objList, float angle, float time)
        {
            objList.ForEach(obj => RotateFromZero(obj, angle, time));
        }

        public static void PushObjLength(GameObject obj, float len)
        {
            obj.transform.position += obj.transform.up * len;
        }

        public static void PushObjLength(List<GameObject> objList,float len)
        {
            objList.ForEach(obj => PushObjLength(obj, len));
        }






    }
}
