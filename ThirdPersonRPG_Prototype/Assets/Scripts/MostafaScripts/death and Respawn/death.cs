﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour {
    public checkPointManager chk;
	// Use this for initialization
	void Start () {

        chk = GameObject.Find("GameManager").GetComponent<checkPointManager>();
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}

    void OnTriggerEnter(Collider coll) {
        if (coll.transform.tag == "Player") {

            coll.transform.position = chk.checkPointPos;
            Debug.Log("Die");
        }
        
    }
}