using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour {
    public checkPointManager chk;
    // Use this for initialization
    void Start() {
        chk = GameObject.Find("GameManager").GetComponent<checkPointManager>();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider coll) {
        if (coll.transform.tag == "Player") {

            chk.checkPointPos = coll.transform.position;
            chk.checkPointRot = coll.transform.rotation;
            chk.cameraRot = GameObject.Find("CameraPivot").transform.rotation;
        }
    }
}
