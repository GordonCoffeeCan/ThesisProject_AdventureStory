using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchBehaviour : MonoBehaviour {

    private PlayerController playerController;

	// Use this for initialization
	void Start () {

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.transform.GetChild(0).gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (playerController.hasTorch == true) {
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            this.transform.GetChild(0).gameObject.SetActive(true);
        }
		
	}
}
