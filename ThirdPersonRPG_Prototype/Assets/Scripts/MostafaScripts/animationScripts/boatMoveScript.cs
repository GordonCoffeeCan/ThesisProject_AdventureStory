using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatMoveScript : MonoBehaviour {

    private GameObject rootPlayer;
    private Animator anim;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider coll) {
        if (coll.transform.tag == "Player") {
            rootPlayer = coll.transform.root.gameObject;

            rootPlayer.transform.parent = this.transform;

            anim.Play("boat_MovesToDestination");

        }
    }

    void OnTriggerExit(Collider coll) {
        if (coll.transform.tag == "Player") {
            rootPlayer.transform.parent = null;

        }
    }
}
