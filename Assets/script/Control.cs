using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //加载资源
        PublicObj.Template.LoadAllResources();
        GameObject.Find("zoufangzi").AddComponent<Zoufangzi>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
