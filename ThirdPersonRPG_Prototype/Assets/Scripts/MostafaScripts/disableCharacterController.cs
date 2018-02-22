using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableCharacterController : MonoBehaviour {
    private GameObject player;

    [SerializeField]
    private Animator playerTposeAnimator;

    [SerializeField]
    private float playerYPos = 0.52f;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");

        playerTposeAnimator = player.GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void disableController() {
        player.GetComponent<PlayerController>().enabled = false;
        playerTposeAnimator.Play("Human_Idle");
        
    }

    void enableController() {
        player.GetComponent<PlayerController>().enabled = true;
    }
}
