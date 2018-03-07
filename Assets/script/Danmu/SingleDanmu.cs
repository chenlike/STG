using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Danmu
{
    class SingleDanmu
    {
        public static Bullet CreateSingleDanmu(GameObject template,Vector3 pos, float angle=0, float flySpeed=0f)
        {
            GameObject bullet =  Utils.DanmuUtils.InitTemplate(template, pos);

            Bullet bul = bullet.GetComponent<Bullet>();
            if (bul == null)
                bul = bullet.AddComponent<Bullet>();
            bul.SetDefault();
            bul.flySpeed = flySpeed;
            Utils.DanmuUtils.ChangeFaceAngle(bullet, angle);

            return bul;
        }
    }
}
