using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerStoneScript : MonoBehaviour{

    private const string PLAYER_TAG = "Player";

    [HideInInspector]
    public float speed = 0;
    [HideInInspector]
    public int damage = 0;

    private float destoryTimer = 8;

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, destoryTimer);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision _col) {
        if (_col.gameObject.tag == PLAYER_TAG) {

            
        }

        Destroy(this.gameObject);
    }
}
