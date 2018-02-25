using UnityEngine;
using System.Collections;
using System;
using System.Reflection;

public class Koishi : Character
{

    void Start()
    {
        SpellDemo t = new SpellDemo();
        t.beforeSpellTime = 0f;
        t.spellKeepTime = 10f;
        spellList.Add(t);
        SpellDemo1 t1 = new SpellDemo1();
        t1.beforeSpellTime = 0f;
        t1.spellKeepTime =30f;
        spellList.Add(t1);
        Spell();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
