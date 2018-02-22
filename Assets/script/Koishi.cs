using UnityEngine;
using System.Collections;

public class Koishi : Character
{

    // Use this for initialization
    void Start()
    {
        SpellDemo a = new SpellDemo();
        spellList.Add(a);
        Spell();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
