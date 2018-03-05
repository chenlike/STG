using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDemo3 : SpellCard
{
    GameObject a;
    GameObject b;
    GameObject player;
    BulletShooter shooter;

    IEnumerator Change(GameObject obj)
    {
        SpriteRenderer bb = b.GetComponent<SpriteRenderer>();
        BulletShooter bs = obj.GetComponent<BulletShooter>();
        while (true)
        {
            var list = Danmu.CircleDanmu.CreateCircleDanmu(a, obj.transform, 36, 0.5f);
            bs.Shoot(list);
            yield return new WaitForSecondsRealtime(1f);
            Utils.DanmuUtils.ReplaceTemplate(list, bb);
            Utils.DanmuUtils.ChangeFocus(list,player.transform.position);
            yield return new WaitForSecondsRealtime(2f);
        }

    }
    void Go(GameObject obj)
    {
        StartCoroutine(Change(obj));
    }
    public override void Prepare()
    {
        player = GameObject.Find("player") as GameObject;
        a = PublicObj.Template.GetTemplate("blueCard");
        b = PublicObj.Template.GetTemplate("redCard");


        shooter = CreateEmptyBulletShooter(new Vector3(0,0,0));
        shooter.startEvent += Go;
    }

    public override void Spell()
    {
        shooter.SetEnable();
    }
    public override void StopSpell()
    {

    }



}
