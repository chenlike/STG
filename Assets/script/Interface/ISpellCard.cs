using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpellCard {
    /// <summary>
    /// 符卡的提前准备工作
    /// </summary>
    void Prepare();
    /// <summary>
    /// 开始施放符卡
    /// </summary>
    void Spell();
}
