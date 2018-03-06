using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Character : Base.GameObjectBase
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
        spellList.ForEach(sc =>
        {
            sc.spellGameObject = this.gameObject;
        });
        //如果大于list长度break
        if (index >= spellList.Count)
        {
            yield break;
        }
        //更新当前index
        nowSpellCardIndex = index;

        //重置位置到 下一个符卡的起始位置
        spellList[index].InitAndLoadResources();

        spellList[index].Prepare();
        MoveTo(spellList[index].startPosition, 1);
        yield return new WaitForSeconds(spellList[index].beforeSpellTime);
        spellList[index].Spell();

        yield return new WaitForSeconds(spellList[index].spellKeepTime);
        spellList[index].StopSpell();


        foreach (var i in GameObject.FindGameObjectsWithTag("EnemyBullet"))
        {
            UnityEngine.Object.Destroy(i);
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

    public void MoveTo(Vector3 newPosition,float time,bool wait=false)
    {
        var itween = this.GetComponent<iTween>();
        if(wait && itween != null)
        {
            return;
        }
        if (wait == false && itween!=null)
        {
            Destroy(itween);
            iTween.MoveTo(this.gameObject, newPosition, time);
        }else if (wait == false)
        {
            iTween.MoveTo(this.gameObject, newPosition, time);
        }
        
    }

    /// <summary>
    /// 增加符卡到list中
    /// </summary>
    /// <param name="spellType">符卡类型(全称 带有命名空间)</param>
    /// <param name="beforeSpellTime">施放前时间</param>
    /// <param name="spellKeepTime">持续时间</param>
    public void AddSpellCard(string spellType, float beforeSpellTime = 0f, float spellKeepTime = 0f)
    {
        //反射
        Type type = System.Type.GetType(spellType);
        var spellCard = Activator.CreateInstance(type);
        type.GetProperty("beforeSpellTime").SetValue(spellCard, beforeSpellTime, null);
        type.GetProperty("spellKeepTime").SetValue(spellCard, spellKeepTime, null);
        spellList.Add((SpellCard)spellCard);
    }
}
