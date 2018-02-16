using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCardTest : SpellCard, ISpellCard
{
    List<GameObject> shooters = new List<GameObject>();
    public void Spell()
    {
        SetActiveList(shooters);
    }

    private void Test(GameObject obj)
    {
        var list = Utils.CircleDanmu.CreateCircleDanmu(
            Utils.DanmuUtil.sceneControl.GetResByName("redCard"),
            new Vector3(0,0,0),36,0.02f
            );
        obj.GetComponent<BulletShooterBase>().Shoot(list);
    }
    private void Test1(GameObject obj)
    {
        var list = Utils.CircleDanmu.CreateCircleDanmu(
            Utils.DanmuUtil.sceneControl.GetResByName("blueCard"),
            new Vector3(0, 1, 0), 36, 0.02f
            );
        obj.GetComponent<BulletShooterBase>().Shoot(list);
    }

    public void Prepare()
    {
        GameObject a = CreateEmptyBulletShooter();
        a.transform.position = new Vector3(0, 0, 0);
        a.GetComponent<BulletShooterBase>().startEvent += Test;
        shooters.Add(a);

        GameObject b = CreateEmptyBulletShooter();
        b.transform.position = new Vector3(0,1, 0);
        b.GetComponent<BulletShooterBase>().startEvent += Test1;
        shooters.Add(b);
    }


}
