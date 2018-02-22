using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDemo : SpellCard
{
    public override void Prepare()
    {

    }
    GameObject t=null;
    void Test(GameObject obj)
    {
        Debug.Log("im " + obj.name);
    }
    IEnumerator a()
    {

        GameObject tem;
        tem = Share.Template.GetTemplate("redBall");
        while (true)
        {
            yield return new WaitForSecondsRealtime(1f);
            var list = Danmu.CircleDanmu.CreateArcDanmu(tem, new Vector3(0, 0, 0), 30f, 180f, 20, 1f);


            t.GetComponent<BulletShooter>().Shoot(list);

        }
    }

    public override void Spell()
    {
        Share.Template.LoadAllResources();
        t = CreateEmptyBulletShooter();
        t.SetActive(true);

        StartCoroutine(a());
    }

    public override void StopSpell()
    {

    }
}
