using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAttack : MonoBehaviour {
	public AnalogController controller;
	Animator animator;

	void Start(){
		animator = GetComponent<Animator>();
	}

	void Awake()
	{
		controller.OnAnalogReleased += Attack;
	}
	
	void OnDestro()
	{
		controller.OnAnalogReleased -= Attack;		
	}

	public void Attack(Vector2 direction){
		print("attack");
		if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
			if(direction.x > 0){
				animator.Play("Hero_Attack_Right");
			} else {
				animator.Play("Hero_Attack_left");
			}
			
		} else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y)){
			if(direction.y > 0){
				animator.Play("Hero_Attack_Up");
			} else {
				animator.Play("Hero_Attack_Down");
			}
		}
	}
}
