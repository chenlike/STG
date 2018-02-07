using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAni : MonoBehaviour {
    Animator ator;
    public void rrest()
    {
        ator.SetInteger("move", 0);
    }

    public void SetMove(int num)
    {
        ator.SetInteger("move", num);
    }
	// Use this for initialization
	void Start () {
        ator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
