using UnityEngine;
using System.Collections;
using System;
using System.Reflection;

public class Koishi : Character
{

    void Start()
    {
        SpellDemo3 t = new SpellDemo3();
        t.beforeSpellTime = 0f;
        t.spellKeepTime = 300000f;
        spellList.Add(t);
        Spell();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
