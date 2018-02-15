using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBackpack : MonoBehaviour {
    public GameObject selectedItem;
    public string nameOfSelectedItem;

    public List<GameObject> itemsInInventory;
    private int invNum = 0;

	// Use this for initialization
	void Start () {
        int sizeOfList = itemsInInventory.Count;
	}
	
	// Update is called once per frame
	void Update () {
        if (itemsInInventory.Count > 0) {
            nameOfSelectedItem = itemsInInventory[invNum].gameObject.name;
        }

		
	}

    public void addToInventory(GameObject pickUp) {
        itemsInInventory.Add(pickUp);

    }
}
