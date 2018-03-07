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
        GameObject[] circles = new GameObject[6];
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
        IEnumerator RandomBall()
        {
   
            while (true)
            {
                yield return new WaitForSeconds(3.5f);

                var ballList1 = Danmu.RandomDanmu.CreateAreaRandomDanmu(
                    new Vector3(-3.68f, 4.26f, 0),
                    new Vector3(2.96f, 1.23f, 0),
                    circles,
                    20,
                    0.3f
                    );
                var ballList2 = Danmu.RandomDanmu.CreateAreaRandomDanmu(
                    new Vector3(-3.68f, 4.26f, 0),
                    new Vector3(2.96f, 1.23f, 0),
                    circles,
                    20,
                    0.3f
                    );

                ballBst.Shoot(ballList1);
                yield return new WaitForSeconds(0.8f);
                ballBst.Shoot(ballList2);


                yield return new WaitForSeconds(0.8f);
                Vector3 playerPos = player.transform.position;
                ballList1.ForEach(obj =>
                {
                    Utils.DanmuUtils.ChangeFocus(obj, playerPos);
                    obj.GetComponent<Bullet>().flySpeed = 1f;
                });
                yield return new WaitForFixedUpdate();
                playerPos = player.transform.position;
                ballList2.ForEach(obj =>
                {
                    Utils.DanmuUtils.ChangeFocus(obj, playerPos);
                    obj.GetComponent<Bullet>().flySpeed = 1f;
                });
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
            ballBst.SetEnable();
        }

        public override void StopSpell()
        {
            Object.Destroy(laserBst);
            Object.Destroy(ballBst);
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
            circles[3] = Template.GetTemplate("smallWhiteBall");
            circles[4] = Template.GetTemplate("blueBall");
            circles[5] = Template.GetTemplate("blueBall");
        }
    }

}
