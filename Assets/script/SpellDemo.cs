using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDemo : SpellCard
{
    public override void Prepare()
    {
        t = CreateEmptyBulletShooter();
        t.GetComponent<BulletShooter>().updateEvent += Ro;
        tem = PublicObj.Template.GetTemplate("pinkMi");
    }
    GameObject t=null;
    GameObject tem;
    IEnumerator a()
    {
        List<GameObject> list = null;
        while (true)
        {

            yield return new WaitForFixedUpdate();


            list = Danmu.CircleDanmu.CreateCircleDanmu(tem, t.transform, 15,0.6f);
            t.GetComponent<BulletShooter>().Shoot(list);
        }
    }
    float speed =4f;
    public void Ro(GameObject obj)
    {
        obj.transform.Rotate(speed*Vector3.forward);
    }

    public override void Spell()
    {
        t.SetActive(true);
        StartCoroutine(a());
    }

    public override void StopSpell()
    {

    }
}
