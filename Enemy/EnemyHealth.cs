using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int health = 20;
	private Enemy enemyScript;

	private Animator anim;

	void Awake() {
		enemyScript = GetComponent<Enemy>();
		anim = GetComponent<Animator>();
	}

	public void ApplyDamage(int damageAmount) {
		health -= damageAmount;

		if (health < 0) {
			health  = 0;
		}

		if (health == 0) {
			enemyScript.enabled = false;
			anim.Play(MyTags.DEAD_TRIGGER);
			SoundManager.instance.PlayEnemyDeadSound();
			Invoke ("DeactivateEnemy", 10f);
		}
	}

	void DeactivateEnemy() {
		gameObject.SetActive(false);
	}
}
