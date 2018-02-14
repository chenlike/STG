using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCardTest : BulletShooterBase {

    public GameObject tem;
    // Use this for initialization
    public float AddAngle;
    void MyShoot()
    {

    }
    List<GameObject> list;
    void Spell()
    {
        list.ForEach(obj =>
        {
            obj.GetComponent<BulletBase>().speed = 0.02f;
        });
    }

    
	void Start () {
        list= Utils.CircleDanmu.CreateArcDanmu(tem, this.transform, 0, 288, 64, 0f, true);
        Utils.TransformUtils.PushObjLength(list, 0.5f);
        list.ForEach(obj =>
        {
            Utils.DanmuUtil.ChangeFocus(obj, transform.position);
            //obj.transform.parent = null;
            //obj.GetComponent<BulletBase>().ChangeFace(obj.GetComponent<BulletBase>().nowAngle + 180);
        });
        ChangeFace(AddAngle);

        

        Shoot(list, 0.05f);
        Invoke("Spell", 5f);
	}
	

}
