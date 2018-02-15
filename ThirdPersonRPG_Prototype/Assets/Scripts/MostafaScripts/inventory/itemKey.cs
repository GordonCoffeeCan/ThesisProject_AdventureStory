using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemKey : MonoBehaviour {

    public GameObject key;
    public GameObject door;
    private string keyName;

	// Use this for initialization
	void Start () {
        keyName = key.name;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider coll) {


        if (coll.transform.tag == "Player") {
            if (coll.gameObject.GetComponent<playerBackpack>().nameOfSelectedItem == keyName) {
                Destroy(door);
            }
        }
    }
}
