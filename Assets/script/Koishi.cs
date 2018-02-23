using UnityEngine;
using System.Collections;

public class Koishi : Character
{

    // Use this for initialization
    void Start()
    {
        SpellDemo1 a = new SpellDemo1();
        a.beforeSpellTime = 0f;
        a.spellKeepTime = 10f;
        spellList.Add(a);
        
        Spell();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
