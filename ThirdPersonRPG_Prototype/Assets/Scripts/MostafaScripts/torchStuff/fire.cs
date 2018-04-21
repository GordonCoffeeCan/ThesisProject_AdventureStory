using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider _col) {
        Debug.Log("Collision" + _col.gameObject.name);

        if (_col.GetComponent<flammable>() != null) {

            Debug.Log(_col.gameObject.name + "is burning");
            _col.GetComponent<flammable>().Burn();
        }

    }
}
