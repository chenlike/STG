using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Utils;

namespace Danmu
{
    public class RandomDanmu
    {
        /// <summary>
        /// 在区域里 随机创建弹幕
        /// </summary>
        /// <param name="leftTopPoint">左上角</param>
        /// <param name="rightBottomPoint">右下角</param>
        /// <param name="templates">模板弹幕组</param>
        /// <param name="num">生成数量</param>
        /// <param name="flySpeed">速度</param>
        /// <param name="faceAngle">面朝方向</param>
        /// <returns></returns>
        public static List<GameObject> CreateAreaRandomDanmu(Vector3 leftTopPoint,Vector3 rightBottomPoint,GameObject[] templates,int num,float flySpeed = 0f,float faceAngle=0f)
        {
            List<GameObject> list = new List<GameObject>();
            int templatesNum = templates.Length;
            
            while (list.Count < num)
            {
                Vector3 pos = new Vector3(Random.Range(leftTopPoint.x, rightBottomPoint.x), Random.Range(leftTopPoint.y, rightBottomPoint.y), 0f);

                int selectIdx = Random.Range(0, templatesNum);

                GameObject bullet = DanmuUtils.InitTemplate(templates[selectIdx], pos);
                bullet.transform.position = pos;
                Bullet script = bullet.GetComponent<Bullet>();
                if (script == null)
                    script = bullet.AddComponent<Bullet>();
                script.SetDefault();
                script.flySpeed = flySpeed;
                Utils.DanmuUtils.ChangeFaceAngle(bullet, faceAngle);
                list.Add(bullet);
            }

        
            return list;
        }

    }
}