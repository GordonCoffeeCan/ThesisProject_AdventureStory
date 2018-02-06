using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class switchCamera : MonoBehaviour {
    public GameObject playerCamera;
    public GameObject fixedCamera;  

    public GameObject Player;
    private bool dynamicCamera;
   

	// Use this for initialization
	void Start () {
        dynamicCamera = true;
        //playerCamera.GetComponent<CinemachineBrain>().enabled = false;
        //camerapivot = playerCamera.transform.parent.transform;
        Player = GameObject.Find("Player");

        //rotationPivotFixedCamera.SetActive(dynamicCamera);
        
       
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C)) {
            dynamicCamera =  !dynamicCamera;
            //playerCamera.GetComponent<CinemachineBrain>().enabled = !dynamicCamera;

            if (dynamicCamera == true) {

                playerCamera.GetComponent<Camera>().depth = 0;
                fixedCamera.GetComponent<Camera>().depth = -1;

            }
            else if (dynamicCamera == false) {

                playerCamera.GetComponent<Camera>().depth = -1;
                fixedCamera.GetComponent<Camera>().depth = 0;

            }



        }



    }
}
