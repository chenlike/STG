using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDemo : SpellCard
{
    public override void Prepare()
    {

    }
    GameObject t=null;

    IEnumerator a()
    {

        GameObject tem;
        tem = PublicObj.Template.GetTemplate("pinkMi");
        List<GameObject> list = null;

        while (true)
        {
            yield return new WaitForSeconds(0.051f);
            list = Danmu.CircleDanmu.CreateCircleDanmu(tem, t.transform, 20,0.6f);
            Utils.DanmuUtils.PushObjLength(list, 0.5f);
            t.GetComponent<BulletShooter>().Shoot(list);
        }
    }
    public void Ro(GameObject obj)
    {
        obj.transform.Rotate(Vector3.forward * 2f);
    }
    public override void Spell()
    {


        t = CreateEmptyBulletShooter();
        t.SetActive(true);
        t.GetComponent<BulletShooter>().updateEvent += Ro;
        StartCoroutine(a());
    }

    public override void StopSpell()
    {

    }
}
