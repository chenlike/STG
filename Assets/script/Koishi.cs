using UnityEngine;
using System.Collections;

public class Koishi : Character
{

    // Use this for initialization
    void Start()
    {
        SpellDemo1 a = new SpellDemo1();
        a.beforeSpellTime = 0f;
        a.spellKeepTime = 30f;
        spellList.Add(a);
        SpellDemo b = new SpellDemo();
        b.beforeSpellTime = 1f;
        b.spellKeepTime = 30f;
        spellList.Add(b);
        Spell();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
