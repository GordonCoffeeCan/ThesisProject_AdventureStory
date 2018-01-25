using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoScript : MonoBehaviour {
    public Vector3 originalPosition;

    public Collider objectTrigger;

	// Use this for initialization
	void Start () {
        originalPosition = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider _col) {
        if(_col.tag == "Player") {

        }
    }
}
