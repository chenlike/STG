using UnityEngine;
using System.Collections;
using PublicObj;
using Danmu;
using System.Collections.Generic;

namespace Boss.zoufangzi
{
    public class SpellCard1 : SpellCard
    {
        GameObject[] lasers = new GameObject[2];
        GameObject[] circles = new GameObject[3];
        GameObject player;


        BulletShooter laserBst;
        BulletShooter ballBst;
        List<GameObject> GetList(int templateIdx, float startAngle, float endAngle,int num,float speed)
        {
            return CircleDanmu.CreateArcDanmu(lasers[templateIdx], spellGameObject.transform, startAngle, endAngle, num, speed);
        }
        IEnumerator Laser()
        {
            int sum = 0;
            int oddSum = 0;
            while (true)
            {
                yield return new WaitForSeconds(3f);
                Utils.DanmuUtils.ChangeFocus(laserBst.gameObject, player.transform.position);
                float angle = laserBst.transform.eulerAngles.z;
                sum++;
                
                if (sum % 2 == 0)
                {
                    int idx1 = 0;
                    int idx2 = 0;
                    float leftAngleStart = 90;
                    float leftAngleEnd = angle - 5;
                    float rightAngleStart = angle + 5f;
                    float rightAngleEnd = 270f;

                    float leftShootDelay = 0.06f;
                    float rightShootDelay = 0.06f;


                    var leftLaserList = GetList(
                        templateIdx: idx1,
                        startAngle: leftAngleStart,
                        endAngle: leftAngleEnd,
                        num: 30,
                        speed: 1f
                     );

                    var rightLaserList = GetList(
                        templateIdx: idx2,
                        startAngle: rightAngleStart,
                        endAngle: rightAngleEnd,
                        num: 30,
                        speed: 1f
                     );


                    rightLaserList.ForEach(obj => { obj.GetComponent<Bullet>().destoryDelayTime = 2f; });
                    rightLaserList.Reverse();
                    laserBst.Shoot(rightLaserList, rightShootDelay);

                    leftLaserList.ForEach(obj => { obj.GetComponent<Bullet>().destoryDelayTime = 2f; });
                    laserBst.Shoot(leftLaserList, leftShootDelay);

                }
                else
                {
                    oddSum++;
                    int idx1 = 0;
                    int idx2 = 0;
                    float leftAngleStart = 90;
                    float leftAngleEnd= angle - 5;
                    float rightAngleStart = angle + 5f;
                    float rightAngleEnd = 270f;

                    float leftShootDelay = 0.06f;
                    float rightShootDelay = 0.06f;


                    if (oddSum % 2 != 0)
                    {
                        idx1 = 1;
                        idx2 = 0;
                        leftAngleEnd = rightAngleStart;
                        leftShootDelay = 0.09f;
                    }
                    else
                    {
                        idx1 = 0;
                        idx2 = 1;
                        rightAngleStart = leftAngleEnd;
                        rightShootDelay = 0.09f;
                    }


                    var leftLaserList = GetList(
                        templateIdx: idx1,
                        startAngle: leftAngleStart,
                        endAngle: leftAngleEnd,
                        num: 30,
                        speed: 1f
                     );

                    var rightLaserList = GetList(
                        templateIdx: idx2,
                        startAngle: rightAngleStart,
                        endAngle: rightAngleEnd,
                        num: 30,
                        speed: 1f
                     );


                    rightLaserList.ForEach(obj => { obj.GetComponent<Bullet>().destoryDelayTime = 2f; });
                    rightLaserList.Reverse();

                    laserBst.Shoot(rightLaserList, rightShootDelay);

                    leftLaserList.ForEach(obj => { obj.GetComponent<Bullet>().destoryDelayTime = 2f; });
                    laserBst.Shoot(leftLaserList, leftShootDelay);



                }






            }


        }
        void GoCoroutineLaser(GameObject obj)
        {
            StartCoroutine(Laser());
        }


        int[] rdList = { 0, 1, 2 };
        IEnumerator RandomBall()
        {
            while (true)
            {
                yield return new WaitForSeconds(2f);

            }
        }
        void GoCoroutineRandomBall(GameObject obj)
        {
            StartCoroutine(RandomBall());
        }


        public override void Prepare()
        {
            laserBst = CreateEmptyBulletShooter(spellGameObject.transform);
            laserBst.startEvent += GoCoroutineLaser;

            ballBst = CreateEmptyBulletShooter(spellGameObject.transform);
            ballBst.startEvent += GoCoroutineRandomBall;
        }

        public override void Spell()
        {
            laserBst.SetEnable();
        }

        public override void StopSpell()
        {

        }
        public override void InitAndLoadResources()
        {
            spellCardName = "开宴 [二拜二拍一拜]";
            startPosition = new Vector3(-0.29f, 2.4f, 0);
            player = GameObject.Find("player") as GameObject;
            lasers[0] = Template.GetTemplate("redLaser");
            lasers[1] = Template.GetTemplate("blueLaser");
            circles[0] = Template.GetTemplate("smallWhiteBall");
            circles[1] = Template.GetTemplate("blueBall");
            circles[2] = Template.GetTemplate("bigBlueBall");
        }
    }

}
