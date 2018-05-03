using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour {

    [SerializeField]
    private torchManager torch;

	// Use this for initialization
	void Start () {
        torch = GameObject.Find("GameManager").GetComponent<torchManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
            torch.isHoldingTorch = true;
        }
    }
}
