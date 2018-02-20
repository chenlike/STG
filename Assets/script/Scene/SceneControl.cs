using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{

    Dictionary<string, GameObject> resources = new Dictionary<string, GameObject>();

    int max = 0;
    public int now = 0;



    /// <summary>
    /// 通过名字返回模板
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject GetResByName(string name)
    {
        return resources[name];
    }
    
    /// <summary>
    /// 加载资源
    /// </summary>
    void LoadAllResources()
    {
        var list = Resources.LoadAll("bullet");
        foreach (var i in list)
        {
            GameObject t = (GameObject)i;
            resources[t.name] = t;
        }
    }






    void Start()
    {
        LoadAllResources();
        GameObject play = Resources.Load("character/player") as GameObject;
        play = Utils.DanmuUtil.InitTemplate(play, new Vector3(0, -3f, 0));
        SpellCardDemo1 a = new SpellCardDemo1();
        a.Prepare();
        a.Spell();
        play.SetActive(true);

    }



}