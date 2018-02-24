using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour
{
    //TODO 
    //CharacterAnimation Control

    public List<SpellCard> spellList = new List<SpellCard>();

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
        //如果大于list长度break
        if (index >= spellList.Count)
        {
            yield break;
        }
        //更新当前index
        nowSpellCardIndex = index;

        spellList[index].Prepare();
        yield return new WaitForSeconds(spellList[index].beforeSpellTime);
        spellList[index].Spell();

        yield return new WaitForSeconds(spellList[index].spellKeepTime);
        spellList[index].StopSpell();


        foreach (var i in GameObject.FindGameObjectsWithTag("EnemyBullet"))
        {
            Object.Destroy(i);
        }

        yield return StartCoroutine(StartSpellCard(index + 1));
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
        StopAllCoroutines();
    }


}
