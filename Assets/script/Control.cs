using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Share.Template.LoadAllResources();
        GameObject.Find("koishi").AddComponent<Koishi>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
