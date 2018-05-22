using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour {
	Rigidbody2D body;
	public float velocity;
	public AnalogController controller;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
	}

	void Awake()
	{
		controller.AnalogValue += Move;
	}
	
	void OnDestro()
	{
		controller.AnalogValue -= Move;		
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		//Move(input);
	}

	void LateUpdate(){
		float x = Mathf.Round(transform.position.x * 10) / 100;
		//print(x);
		float y = Mathf.Round(transform.position.y * 10) / 100;
		//transform.position = new Vector2(x, y);
	}

	public void Move(Vector2 direction){
		if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
			body.velocity = Vector2.right * Mathf.Sign(direction.x) * velocity;
		} else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y)){
			body.velocity = Vector2.up * Mathf.Sign(direction.y) * velocity;
		} else {
			body.velocity = Vector2.zero;
		}

		//body.velocity = direction * velocity;
	}
}
