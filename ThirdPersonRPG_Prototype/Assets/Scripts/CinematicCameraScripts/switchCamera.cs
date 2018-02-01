using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchCamera : MonoBehaviour {
    public GameObject playerCamera;
    public GameObject cinemachineCamera;

	// Use this for initialization
	void Start () {
        cinemachineCamera.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C)) {
            if (playerCamera.activeInHierarchy) {
                playerCamera.SetActive(false);
                cinemachineCamera.SetActive(true);
            }
            else {
                playerCamera.SetActive(true);
                cinemachineCamera.SetActive(false);
            }
        }

    }
}
