﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableCharacterController : MonoBehaviour {
    private GameObject player;

    [SerializeField]
    private Animator playerTposeAnimator;

    [SerializeField]
    private float playerYPos = 0.52f;

    private bool playerDisabled = false;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");

        playerTposeAnimator = player.GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerDisabled == true) {
            playerTposeAnimator.SetFloat("Speed", 0);
            playerTposeAnimator.SetBool("IsGrounded", true);

            playerTposeAnimator.Play("Human_Idle");
            playerTposeAnimator.SetBool("Jump", false);

            player.GetComponent<PlayerController>().enabled = false;
        }
		
	}

    void disableController() {
        //player.GetComponent<PlayerController>().enabled = true;
        //playerTposeAnimator.Play("Human_Idle");
        playerDisabled = true;  

        playerTposeAnimator.SetFloat("Speed", 0);
        playerTposeAnimator.SetBool("IsGrounded", true);

        playerTposeAnimator.Play("Human_Idle");

        player.GetComponent<PlayerController>().enabled = false;


    }

    void enableController() {
        playerDisabled = false;
        player.GetComponent<PlayerController>().enabled = true;
    }
}
