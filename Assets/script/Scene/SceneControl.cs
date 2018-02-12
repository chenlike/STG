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
            yield return new WaitForSeconds(1);
            now += 1;
            if (now > max)
            {
                PlayerPrefs.SetInt("max", now);
                max = now;
            }
            SetNum();
        }
    }

    public GameObject GetResByName(string name)
    {
        return resources[name];
    }
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


        max = PlayerPrefs.GetInt("max");
        StartCoroutine(ttime());
        GameObject play = Resources.Load("character/player") as GameObject;
        GameObject enm = Resources.Load("character/aboluo123") as GameObject;
        play = Utils.DanmuUtil.InitTemplate(play, new Vector3(0, -3, 0));
        enm = Utils.DanmuUtil.InitTemplate(enm, new Vector3(0, 3, 0));


        CharacterBase doremiChararcterBase =  enm.AddComponent<CharacterBase>();
        doremiChararcterBase.spellList.Add();







        play.SetActive(true);
        enm.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }



}