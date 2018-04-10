using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchHandLink : MonoBehaviour {
    public GameObject hand;

	// Use this for initialization
	void Start () {
        hand = GameObject.Find("mixamorig:LeftHand");
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = hand.transform.position;
	}
}
