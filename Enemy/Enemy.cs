using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	private GameObject player;
	private Rigidbody myBody;
	private Animator anim;

	private float enemy_Speed = 10f;
	private float enemy_Watch_Threshold = 70f;
	private float enemy_Attack_Threshold = 6f;

	public GameObject damagePoint;

	void Awake() {
		player = GameObject.FindGameObjectWithTag("Player");
		myBody = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
	}

	void Start () {
		
	}

	void FixedUpdate () {
		if (GamePlayController.instance.isPlayerAlive) {
			EnemyAI();
		}
		else {
			if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION) || anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_ANIMATION)) {

				anim.SetTrigger(MyTags.STOP_TRIGGER);
			}
		}
	}

	void EnemyAI() {
		Vector3 direction = player.transform.position - transform.position;
		float distance = direction.magnitude;
		direction.Normalize();

		Vector3 velocity = direction * enemy_Speed;

		if (distance > enemy_Attack_Threshold && distance < enemy_Watch_Threshold) {
			myBody.velocity = new Vector3 (velocity.x, myBody.velocity.y, velocity.z);

			if (anim.GetCurrentAnimatorStateInfo(0).IsName (MyTags.ATTACK_ANIMATION )){
				anim.SetTrigger (MyTags.STOP_TRIGGER);
			}
			
			anim.SetTrigger (MyTags.RUN_TRIGGER);
			transform.LookAt (new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
		}
		else if (distance < enemy_Attack_Threshold) {

			if (anim.GetCurrentAnimatorStateInfo(0).IsName (MyTags.RUN_ANIMATION)) {
				anim.SetTrigger (MyTags.STOP_TRIGGER);
			}

			anim.SetTrigger (MyTags.ATTACK_TRIGGER);
			transform.LookAt (new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
		}
		else {
			myBody.velocity = new Vector3 (0f, 0f, 0f);

			if (anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.RUN_ANIMATION) || anim.GetCurrentAnimatorStateInfo(0).IsName(MyTags.ATTACK_ANIMATION)) {
				anim.SetTrigger (MyTags.STOP_TRIGGER);
			}
		}
		
	}

	public void ActivateDamagePoint() {
		damagePoint.SetActive(true);
	}
	
	public void DeactivateDamagePoint() {
		damagePoint.SetActive(false);
	}

}
