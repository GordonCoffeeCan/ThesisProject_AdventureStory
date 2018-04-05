using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointManager : MonoBehaviour {
    public Vector3 checkPointPos;

	// Use this for initialization
	void Start () {
        checkPointPos = GameObject.Find("Player").transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
