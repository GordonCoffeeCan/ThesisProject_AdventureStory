using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class switchCamera : MonoBehaviour {
    //public GameObject playerCamera;
    public GameObject mainCamera;
    public GameObject fixedCamera;

    private bool mainCameraActive;
    private bool fixedCameraActive;

	// Use this for initialization
	void Start () {
        //playerCamera.GetComponent<CinemachineBrain>().enabled = false;
        mainCamera.SetActive(true);
        fixedCamera.SetActive(false);

        mainCameraActive = true;
        fixedCameraActive = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C)) {
            // playerCamera.GetComponent<CinemachineBrain>().enabled = !dynamicCamera;

            mainCameraActive = !mainCameraActive;
            fixedCameraActive = !fixedCameraActive;

            mainCamera.SetActive(mainCameraActive);
            fixedCamera.SetActive(fixedCameraActive);
            
            
        }

       

    }
}
