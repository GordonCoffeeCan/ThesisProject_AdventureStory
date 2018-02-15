using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickUp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider coll) {
        if (coll.transform.tag == "Player") {
            coll.gameObject.GetComponent<playerBackpack>().addToInventory(this.gameObject);
            this.gameObject.transform.position = new Vector3(1000, 1000, 1000);
        }
    }
}
