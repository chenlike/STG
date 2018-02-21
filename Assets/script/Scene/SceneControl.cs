using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{

    Dictionary<string, GameObject> resources = new Dictionary<string, GameObject>();
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
        var bullet = Resources.LoadAll("bullet");
        var character = Resources.LoadAll("character");
        var other = Resources.LoadAll("other");
        foreach (var i in bullet)
        {
            GameObject t = (GameObject)i;
            resources[t.name] = t;
        }
        foreach (var i in character)
        {
            GameObject t = (GameObject)i;
            resources[t.name] = t;
        }
        foreach (var i in other)
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

        play.SetActive(true);
        GameObject.Find("koishi").AddComponent<Koishi>();
    }


}