using UnityEngine;
using System.Collections;

public class Koishi : CharacterBase
{

    void Start()
    {
        SpellCardDemo a = new SpellCardDemo();
        SpellCardDemo1 b = new SpellCardDemo1();
        a.spellKeepTime = 20f;
        b.spellKeepTime = 20f;
        b.beforeSpellTime = 3f;
        spellList.Add(b);
        spellList.Add(a);
        Spell();
    }
    void Update()
    {

    }


}
