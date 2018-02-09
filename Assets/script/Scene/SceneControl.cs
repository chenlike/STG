using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour {

    int max = 0;
    public int now = 0;
    void SetNum()
    {
        GameObject text = GameObject.Find("Text");
        text.GetComponent<Text>().text = "Max:" + max + " \nNow:" + now;
    }
    IEnumerator ttime()
    {
        SetNum();
        while (true)
        {
            yield return new WaitForSeconds(1);
            now += 1;
            if(now > max)
            {
                PlayerPrefs.SetInt("max", now);
                max = now;
            }
            SetNum();
        }
    }
	// Use this for initialization
	void Start () {
        max = PlayerPrefs.GetInt("max");
        StartCoroutine(ttime());
        GameObject play = Resources.Load("character/player") as GameObject;
        GameObject enm = Resources.Load("character/aboluo123") as GameObject;
        play = DanmuLib.DanmuUtil.InitTemplate(play, new Vector3(0,-3,0));
        enm = DanmuLib.DanmuUtil.InitTemplate(enm, new Vector3(0, 3, 0));
        play.SetActive(true);
        enm.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}



}
