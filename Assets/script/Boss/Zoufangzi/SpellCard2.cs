using UnityEngine;
using System.Collections;
namespace Boss.zoufangzi
{
    public class SpellCard2 : SpellCard
    {

        GameObject redLaser;
        GameObject greenLaser;
        GameObject blue;

        BulletShooter greenShooter;
        BulletShooter redShooter;
        BulletShooter blueShooter;

        float maxAngle = 165f;
        float minAngle = 110f;
        float addSpeed = 0.3f;
        /// <summary>
        /// 触屏到墙壁
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="touchObj"></param>
        public void TouchWall(GameObject obj, GameObject touchObj)
        {
            if (touchObj.gameObject.transform.parent != null && touchObj.gameObject.transform.parent.gameObject.name == "Wall")
            {
                string touchName = touchObj.name;
                Utils.DanmuUtils.PushObjLength(obj, 0.55f);
                //触碰到上左右反弹 
                if (touchName == "down")
                {
                    Utils.DanmuUtils.ChangeFaceAngle(obj, (180f - obj.transform.eulerAngles.z));
                }
                else
                {
                    Utils.DanmuUtils.ChangeFaceAngle(obj, 360f - obj.transform.eulerAngles.z);
                }
                
                var blt = obj.GetComponent<Bullet>();
                blt.touchEvent -= TouchWall;
            }
        }
        IEnumerator ShootGreenLaserEvent()
        {
            float angle = 130f;
            float added = 1f;
            while (true)
            {
                angle += addSpeed * added;
                for (int i=0;i<3;i++)
                    yield return new WaitForFixedUpdate();
                if (angle >= maxAngle || angle <= minAngle)
                {
                    added *= -1;
                }

                var dmL = Danmu.SingleDanmu.CreateSingleDanmu(
                    greenLaser,
                    spellGameObject.transform.position,
                    angle, 
                    1f);

                var dmR = Danmu.SingleDanmu.CreateSingleDanmu(
                    greenLaser,
                    spellGameObject.transform.position,
                   -1*(angle),
                    1f);

                dmL.touchEvent += TouchWall;
                dmR.touchEvent += TouchWall;


                redShooter.Shoot(dmL);
                redShooter.Shoot(dmR);

            }
        }
        void GoShootGreenLaserEvent(GameObject obj)
        {
            StartCoroutine(ShootGreenLaserEvent());
        }
        IEnumerator ShootRedLaserEvent()
        {
            float angle = 130f;
            float added = -1f;
            while (true)
            {
                angle += addSpeed * added;
                for (int i = 0; i < 3; i++)
                    yield return new WaitForFixedUpdate();
                if (angle >= maxAngle || angle <= minAngle)
                {
                    added *= -1;
                }

                var dmL = Danmu.SingleDanmu.CreateSingleDanmu(
                    redLaser,
                    spellGameObject.transform.position,
                    angle,
                    1f);

                var dmR = Danmu.SingleDanmu.CreateSingleDanmu(
                    redLaser,
                    spellGameObject.transform.position,
                   -1 * (angle),
                    1f);

                dmL.touchEvent += TouchWall;
                dmR.touchEvent += TouchWall;


                redShooter.Shoot(dmL);
                redShooter.Shoot(dmR);

            }
        }
        void GoShootRedLaserEvent(GameObject obj)
        {
            StartCoroutine(ShootRedLaserEvent());
        }


        IEnumerator ShootBlueEvent()
        {
            int sum = 0;
            while (true)
            {
                var list = Danmu.CircleDanmu.CreateArcDanmuEmpty(blue
                    , spellGameObject.transform.position, 140f, 220f, 72, 0.4f);
                blueShooter.Shoot(list);
                sum++;
                if (sum % 7 == 0)
                {
                    var fullCircle = Danmu.CircleDanmu.CreateCircleDanmu(blue,
                        spellGameObject.transform.position, 72, 0.2f);
                    blueShooter.Shoot(fullCircle);
                }
                yield return new WaitForSeconds(1f);
            }
        }
        void GoShootBlueEvent(GameObject obj)
        {
            StartCoroutine(ShootBlueEvent());
        }
        public override void Prepare()
        {
            greenShooter.startEvent += GoShootGreenLaserEvent;
            redShooter.startEvent += GoShootRedLaserEvent;
            blueShooter.startEvent += GoShootBlueEvent;
        }

        public override void Spell()
        {
            redShooter.SetEnable();
            greenShooter.SetEnable();
            blueShooter.SetEnable();
        }

        public override void StopSpell()
        {
            Object.Destroy(redShooter);
            Object.Destroy(greenShooter);
            Object.Destroy(blueShooter);
        }


        public override void InitAndLoadResources()
        {
            spellCardName = "土著神[手长足长大人]";
            startPosition.y += 1.5f;
            blue = PublicObj.Template.GetTemplate("blueMi");
            redLaser = PublicObj.Template.GetTemplate("redLaser");
            greenLaser = PublicObj.Template.GetTemplate("greenLaser");
            greenShooter = CreateEmptyBulletShooter(spellGameObject.transform);
            redShooter = CreateEmptyBulletShooter(spellGameObject.transform);
            blueShooter = CreateEmptyBulletShooter(spellGameObject.transform);
        }

    }

}
