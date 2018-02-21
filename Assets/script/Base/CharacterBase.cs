using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CharacterBase: MonoBehaviour
{
    //TODO 
    //CharacterAnimation Control

    public List<SpellCardBase> spellList = new List<SpellCardBase>();

    /// <summary>
    /// 当前符卡位置
    /// </summary>
    public int nowSpellCardIndex = 0;

    /// <summary>
    /// 施放符卡
    /// </summary>
    /// <param name="index">spellList index</param>
    /// <returns></returns>
    IEnumerator StartSpellCard(int index)
    {
        nowSpellCardIndex = index;
        if (index >=spellList.Count)
        {
            yield break;
        }

        spellList[index].Prepare();
        yield return new WaitForSecondsRealtime(spellList[index].beforeSpellTime);
        spellList[index].Spell();

        yield return new WaitForSecondsRealtime(spellList[index].spellKeepTime);
        spellList[index].StopSpell();
        yield return StartCoroutine(StartSpellCard(index+1));
    }

    /// <summary>
    /// 从index开始施放符卡
    /// </summary>
    /// <param name="index"></param>
    protected void Spell(int index)
    {
        StartCoroutine(StartSpellCard(index));
    }
    protected void Spell()
    {
        StartCoroutine(StartSpellCard(0));
    }

    /// <summary>
    /// 停止施放
    /// </summary>
    protected void StopNowSpell()
    {
        StopCoroutine("StartSpellCard");
    }




    


}

