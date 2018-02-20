using UnityEngine;
using System.Collections;

namespace Utils
{
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
            obj.transform.position = pos;
            bul.speed = speed;
            
            return obj;
        }


        public static GameObject CreateSingleDanmu(GameObject bulletTemplate, Transform ts, float speed)
        {
            return CreateSingleDanmu(bulletTemplate, ts, 0, speed, false);
        }
    }
}
