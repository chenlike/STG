using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDemo : SpellCard
{
    public override void Prepare()
    {
        t = CreateEmptyBulletShooter();
        t.updateEvent += Ro;
        tem = PublicObj.Template.GetTemplate("pinkMi");
    }

    BulletShooter t=null;
    GameObject tem;


    IEnumerator a()
    {
        List<GameObject> list = null;
        while (true)
        {

            yield return new WaitForFixedUpdate();


            list = Danmu.CircleDanmu.CreateCircleDanmu(tem, t.transform, 5,0.6f);
            t.GetComponent<BulletShooter>().Shoot(list);
        }
    }
    float speed = 0f;
    public void Ro(GameObject obj)
    {
        speed += 0.1f;
        obj.transform.Rotate(Vector3.forward*speed);
    }

    public override void Spell()
    {
        t.SetEnable();
        StartCoroutine(a());
    }

    public override void StopSpell()
    {

    }
}
