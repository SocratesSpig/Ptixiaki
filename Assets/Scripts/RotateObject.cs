using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime * 6);
        transform.Translate(new Vector3(0, 0, Mathf.Sin(Time.time * 8)) * Time.deltaTime);
	}
}
