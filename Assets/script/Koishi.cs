using UnityEngine;
using System.Collections;
using System;
using System.Reflection;

public class Koishi : Character
{

    void Start()
    {
        SpellDemo2 t = new SpellDemo2();
        t.beforeSpellTime = 0f;
        t.spellKeepTime = 1000f;
        spellList.Add(t);

        Spell();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
