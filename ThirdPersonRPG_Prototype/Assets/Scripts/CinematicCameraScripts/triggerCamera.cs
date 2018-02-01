using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerCamera : MonoBehaviour {

    public GameObject vCam;
   

    private GameObject gameManager;
	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager");
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider coll) {
        gameManager.GetComponent<cameraActivateTrigger>().currentVirtualCamera.SetActive(false);
        gameManager.GetComponent<cameraActivateTrigger>().currentVirtualCamera = vCam;


        vCam.SetActive(true);
    }
}
