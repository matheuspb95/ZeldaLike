using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickerEnemy : MonoBehaviour {
	Rigidbody2D body;
	public float velocity;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		body.velocity = Vector2.one * velocity;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(Mathf.Abs(body.velocity.x) != Mathf.Abs(body.velocity.y)){
			print("Error");
			body.velocity = new Vector2(Mathf.Sign(body.velocity.x) * velocity, 
										Mathf.Sign(body.velocity.y) * velocity);
		}		
	}
}
