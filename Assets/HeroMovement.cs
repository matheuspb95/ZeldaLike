using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour {
	Rigidbody2D body;
	public float velocity;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		Move(input, velocity);
	}

	void LateUpdate(){
		float x = Mathf.Round(transform.position.x * 10) / 100;
		//print(x);
		float y = Mathf.Round(transform.position.y * 10) / 100;
		//transform.position = new Vector2(x, y);
	}

	public void Move(Vector2 direction, float velocity){
		body.velocity = direction * velocity;
	}
}
