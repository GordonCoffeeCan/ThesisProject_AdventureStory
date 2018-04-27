using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodboardsBurnUp : MonoBehaviour {
    private GameObject parentObj;

	// Use this for initialization
	void Start () {

        parentObj = this.transform.parent.gameObject;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (parentObj.GetComponent<MeshRenderer>().enabled == false) {
            Destroy(this.gameObject);
        }
	}
}
