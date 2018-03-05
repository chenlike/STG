using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fei1 : SpellCard
{
    GameObject tem;
    BulletShooter blts;
    GameObject player;
    int[] rd = { -1, 0, 1 };
    IEnumerator CircleEvent(GameObject obj)
    {

        int loop = 1;
        int sum = 0;
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            sum++;
            Utils.DanmuUtils.ChangeFocus(obj, player.transform.position);
            loop *= -1;
            for (int i = 1; i <= 4; i++)
            {
                var circle = Danmu.CircleDanmu.CreateCircleDanmu(tem, obj.transform, 28,0.3f+i*0.05f);
                circle.ForEach(dm =>
                {
                    Utils.DanmuUtils.ChangeFaceAngle(dm, dm.transform.eulerAngles.z + (i+0.5f) * loop);
                });
                blts.Shoot(circle);
                for(int j=0;j<2;j++)
                    yield return new WaitForFixedUpdate();

                if (sum %4== 0)
                {
                    
                    Vector3 newPosition = spellGameObject.transform.position;

                    var x = rd[Random.Range(0, rd.Length)];
                    var y = rd[Random.Range(0, rd.Length)];
                    newPosition.x += x;
                    newPosition.y += y;
                    //TODO 人物随机移动
                    //iTween.MoveTo(spellGameObject, newPosition, 1f);
                }
            }


        }
    }
    void GoCoroutine(GameObject obj)
    {
        StartCoroutine(CircleEvent(obj));
    }

    public override void Prepare()
    {
        InitRes();
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
    void InitRes()
    {
        tem = PublicObj.Template.GetTemplate("blueCard");
    }
}
