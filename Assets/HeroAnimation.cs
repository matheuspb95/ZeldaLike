using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimation : MonoBehaviour {
	Animator anim;
	public AnalogController controller;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	void Awake(){
		controller.AnalogValue += AnimController;
	}

	void OnDestroy(){
		controller.AnalogValue -= AnimController;
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		//AnimController(new Vector2(h,v));
	}

	public void AnimController(Vector2 dir){
		if(dir.x == 0 && dir.y == 0){
			//anim.Play("Stop");
		} else {
			if(Mathf.Abs(dir.x) < Mathf.Abs(dir.y)){
				anim.Play("Vertical");
			} else {
				anim.Play("Horizontal");
			}
		}
	}
}
