using UnityEngine;
using System.Collections;

public class Zoufangzi : Character
{
    void Start()
    {
        Fei1 fei1 = new Fei1();
        fei1.beforeSpellTime = 0;
        fei1.spellKeepTime = 60f;
        spellList.Add(fei1);
        Spell();
    }

    // Update is called once per frame
    void Update()
    {

    }



}
