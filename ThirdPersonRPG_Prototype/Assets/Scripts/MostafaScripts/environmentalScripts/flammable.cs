using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flammable : MonoBehaviour {
    public bool isFlammable;

	// Use this for initialization
	void Start () {
        isFlammable = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Fire") {
            Debug.Log("This log is burning");
            Burn();

        }
    }

    public void Burn() {
        Destroy(this.gameObject);

    }
}
