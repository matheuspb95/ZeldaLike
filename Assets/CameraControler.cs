using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraControler : MonoBehaviour {
	public float width = 5;
	public Camera main;
	// Use this for initialization
	void Start () {
		main = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		main.orthographicSize = width / main.aspect;
		main.transform.position = new Vector3(main.transform.position.x, (8 - main.orthographicSize), main.transform.position.z);
	}
}
