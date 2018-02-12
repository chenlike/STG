using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.script.Interface;

public class SpellCard
{
    public string name { get; set; }
    public List<GameObject> shooters = new List<GameObject>();

    public void Start()
    {
        

        shooters.ForEach(obj =>
        {
            obj.GetComponent<IBulletShooter>().PrePare();
        });
        shooters.ForEach(obj =>
        {
            obj.GetComponent<IBulletShooter>().StartShoot();
        });
    }



}
