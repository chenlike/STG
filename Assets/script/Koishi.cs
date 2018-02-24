using UnityEngine;
using System.Collections;

public class Koishi : Character
{

    // Use this for initialization
    void Start()
    {
        SpellDemo t = new SpellDemo();
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
