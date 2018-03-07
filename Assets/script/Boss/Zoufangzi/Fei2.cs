
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Boss.zoufangzi
{
    public class Fei2 : SpellCard
    {
        GameObject red;
        GameObject blue;

        BulletShooter bs;
        public override void InitAndLoadResources()
        {
            spellCardName = "2非";
            blue = PublicObj.Template.GetTemplate("blueCard");
            red = PublicObj.Template.GetTemplate("redCard");
        }
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

                //触碰到上左右反弹 
                if (touchName == "up")
                {
                    Utils.DanmuUtils.ChangeFaceAngle(obj, (180f - obj.transform.eulerAngles.z));
                }
                else if (touchName == "down")
                {
                    return;
                }
                else
                {
                    Utils.DanmuUtils.ChangeFaceAngle(obj, 360f - obj.transform.eulerAngles.z);
                }

                Utils.DanmuUtils.ReplaceTemplate(obj, red);
                var blt = obj.GetComponent<Bullet>();
                blt.flySpeed = 0.4f;
                blt.touchEvent -= TouchWall;
            }
        }
        IEnumerator Circle()
        {
            var character = spellGameObject.GetComponent<Character>();
            while (true)
            {
                yield return new WaitForSeconds(1f);
                var list1 = Danmu.CircleDanmu.CreateCircleDanmu(blue,spellGameObject.transform,32,0.6f);
                var list2 = Danmu.CircleDanmu.CreateCircleDanmu(blue, spellGameObject.transform, 32, 0.5f);
                list1.ForEach(b => b.touchEvent += TouchWall);
                list2.ForEach(b => b.touchEvent += TouchWall);
                bs.Shoot(list1);
                yield return new WaitForFixedUpdate();
                bs.Shoot(list2);

                Vector3 newPos = spellGameObject.transform.position;
                newPos.x += Random.Range(-1f, 1f);
                newPos.y += Random.Range(-1f, 1f);
                character.MoveTo(newPos, 1);
            }
        }

        void GoCircle(GameObject obj)
        {
            StartCoroutine(Circle());
        }
        public override void Prepare()
        {
            bs = CreateEmptyBulletShooter(spellGameObject.transform);
            bs.startEvent += GoCircle;
        }

        public override void Spell()
        {
            bs.SetEnable();
        }

        public override void StopSpell()
        {
            Object.Destroy(bs);
            Object.Destroy(bs.GetComponent<iTween>());
        }
    }
}
