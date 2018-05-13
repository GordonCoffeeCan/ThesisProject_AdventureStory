using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sun : MonoBehaviour {
    public float rotationFloat;
  


    // Use this for initialization
    // Use this for initialization
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        transform.RotateAround(Vector3.zero, Vector3.right, rotationFloat * Time.deltaTime);
        transform.LookAt(Vector3.zero);
      
    }
}
