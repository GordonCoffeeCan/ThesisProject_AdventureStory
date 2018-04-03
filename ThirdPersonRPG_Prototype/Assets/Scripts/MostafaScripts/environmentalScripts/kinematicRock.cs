using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kinematicRock : MonoBehaviour {
    public GameObject parentRock;

	// Use this for initialization
	void Start () {
        parentRock = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
            parentRock.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
