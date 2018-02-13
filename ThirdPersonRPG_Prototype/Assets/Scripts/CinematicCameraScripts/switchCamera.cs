using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class switchCamera : MonoBehaviour {
    public GameObject playerCamera;
    public GameObject fixedCamera;  

    public GameObject Player;
    private bool dynamicCamera;
    private GameObject gameManager;


    // Use this for initialization
    void Start () {
        dynamicCamera = true;
        //playerCamera.GetComponent<CinemachineBrain>().enabled = false;
        //camerapivot = playerCamera.transform.parent.transform;
        Player = GameObject.Find("Player");

        //rotationPivotFixedCamera.SetActive(dynamicCamera);
        gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<cameraActivateTrigger>().currentVirtualCamera = playerCamera;


    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("camera")) {
            dynamicCamera =  !dynamicCamera;

            bool canRotate = Player.transform.Find("CameraPivot").gameObject.GetComponent<CameraDynamicOrbit>().canRotate;
            //playerCamera.GetComponent<CinemachineBrain>().enabled = !dynamicCamera;

            if (dynamicCamera == true) {

                playerCamera.GetComponent<Camera>().depth = 0;
                fixedCamera.GetComponent<Camera>().depth = -1;
                //Player.transform.Find("CameraPivot").gameObject.GetComponent<CameraDynamicOrbit>().canRotate = false;
                //Player.GetComponent<PlayerController>().playerCamera = fixedCamera.GetComponent<Camera>();

                

            }
            else if (dynamicCamera == false) {

                playerCamera.GetComponent<Camera>().depth = -1;
                fixedCamera.GetComponent<Camera>().depth = 0;
                //Player.transform.Find("CameraPivot").gameObject.GetComponent<CameraDynamicOrbit>().canRotate = true;
                //Player.GetComponent<PlayerController>().playerCamera = playerCamera.GetComponent<Camera>();

            }



        }



    }
}
