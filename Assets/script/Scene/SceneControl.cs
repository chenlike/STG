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



    void SetNum()
    {
        GameObject text = GameObject.Find("score");
        text.GetComponent<Text>().text = "Max:" + max + " \nNow:" + now;
    }
    IEnumerator ttime()
    {
        SetNum();
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);
            now += 1;
            if (now > max)
            {
                PlayerPrefs.SetInt("max", now);
                max = now;
            }
            SetNum();
        }
    }



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





    // Use this for initialization
    void Start()
    {
        LoadAllResources();


        GameObject play = Resources.Load("character/player") as GameObject;

        play = Utils.DanmuUtil.InitTemplate(play, new Vector3(0, -3, 0));

        SpellCardDemo a = new SpellCardDemo();
        a.Prepare();
        a.Spell();

        


        play.SetActive(true);

    }



}