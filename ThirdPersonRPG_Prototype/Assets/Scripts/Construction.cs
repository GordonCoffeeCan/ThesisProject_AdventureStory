using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Construction : MonoBehaviour {

    public GameObject[] scaffolds;
    public float constructionMaterialsCollected;

    // Use this for initialization
    void Start() {

        for(int i = 0; i < scaffolds.Length; i++) {

            Color transparentColor = scaffolds[i].GetComponent<Renderer>().material.color;

            transparentColor.a = 0;

            scaffolds[i].GetComponent<Renderer>().material.color = transparentColor;
            GameObject scaffoldChild = scaffolds[i].transform.GetChild(0).gameObject;
            scaffoldChild.SetActive(false);
            scaffolds[i].GetComponent<Collider>().enabled = false;
        }

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider _col) {
        if (_col.tag == "Player") {
            
        }
    }
}
