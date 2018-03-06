using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Boss.zoufangzi
{
    public class Fei1 : SpellCard
    {
        GameObject tem;
        BulletShooter blts;
        GameObject player;
        int[] rd = { -2, -1, 0, 1, 2 };
        IEnumerator CircleEvent(GameObject obj)
        {

            int loop = 1;
            int sum = 0;
            var character = spellGameObject.GetComponent<Character>();
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                sum++;
                Utils.DanmuUtils.ChangeFocus(obj, player.transform.position);
                loop *= -1;
                for (int i = 1; i <= 4; i++)
                {
                    var circle = Danmu.CircleDanmu.CreateCircleDanmu(tem, obj.transform, 28, 0.3f + i * 0.05f);
                    circle.ForEach(dm =>
                    {
                        Utils.DanmuUtils.ChangeFaceAngle(dm, dm.transform.eulerAngles.z + (i + 0.5f) * loop);
                    });
                    blts.Shoot(circle);
                    for (int j = 0; j < 2; j++)
                        yield return new WaitForFixedUpdate();
                }


                if (sum % 2 == 0)
                {
                    Vector3 newPosition = spellGameObject.transform.position;
                    var x = rd[Random.Range(0, rd.Length)];
                    var y = rd[Random.Range(0, rd.Length)];
                    newPosition.x += x * 0.5f;
                    newPosition.y += y * 0.5f;
                    if (newPosition.y < 0)
                    {
                        newPosition.y = spellGameObject.transform.position.y;
                    }
                    character.MoveTo(newPosition, 1.5f);
                }


            }
        }
        void GoCoroutine(GameObject obj)
        {
            StartCoroutine(CircleEvent(obj));
        }

        public override void Prepare()
        {
            player = GameObject.Find("player") as GameObject;
            blts = CreateEmptyBulletShooter(spellGameObject.transform.position);
            blts.transform.parent = spellGameObject.transform;
            blts.startEvent += GoCoroutine;

        }

        public override void Spell()
        {
            blts.SetEnable();
        }

        public override void StopSpell()
        {
            Object.Destroy(blts);
        }

        public override void InitAndLoadResources()
        {
            tem = PublicObj.Template.GetTemplate("blueCard");
        }
    }

}
