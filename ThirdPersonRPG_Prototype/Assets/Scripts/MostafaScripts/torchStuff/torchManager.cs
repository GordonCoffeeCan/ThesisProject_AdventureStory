using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchManager : MonoBehaviour {

    private GameObject player;
    private PlayerController playerController;

    public bool isHoldingTorch;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
        

	}
	
	// Update is called once per frame
	void Update () {
        if (isHoldingTorch == true) {
            playerController.hasTorch = true;
       

        }
    }
}
