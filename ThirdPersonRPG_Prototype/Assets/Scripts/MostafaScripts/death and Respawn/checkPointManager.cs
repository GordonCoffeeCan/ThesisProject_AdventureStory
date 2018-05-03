using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPointManager : MonoBehaviour {
    public Vector3 checkPointPos;

    public Quaternion checkPointRot;

    public Quaternion cameraRot;

	// Use this for initialization
	void Start () {
        checkPointPos = GameObject.Find("Player").transform.position;
        checkPointRot = GameObject.Find("Player").transform.rotation;
        cameraRot = GameObject.Find("CameraPivot").transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
