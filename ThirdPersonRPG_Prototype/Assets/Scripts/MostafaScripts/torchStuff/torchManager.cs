using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchManager : MonoBehaviour {

    private GameObject player;
    private PlayerController playerController;

    public bool isHoldingTorch;

    private GameObject playerTorch;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();

        playerTorch = GameObject.Find("playerTorch");
        

	}
	
	// Update is called once per frame
	void Update () {

        if (isHoldingTorch == true) {
            playerController.hasTorch = true;
            playerTorch.SetActive(true);
        }
        else {
            playerController.hasTorch = false;
            playerTorch.SetActive(false);
        }

       
    }
}
