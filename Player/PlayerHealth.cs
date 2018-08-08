using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int health = 100;

	private PlayerScript playerScript;

	private Animator anim;

	void Awake()
	{
		playerScript = GetComponent<PlayerScript>();
		anim = GetComponent<Animator>();
	}

	void Start()	
	{
		GamePlayController.instance.DisplayHealth(health);
	}
	
	public void ApplyDamage(int damageAmount) {
		health -= damageAmount;

		if (health < 0) {
			health = 0;
		}

		GamePlayController.instance.DisplayHealth(health);

		if (health == 0) {
			playerScript.enabled = false;
			anim.Play (MyTags.DEAD_ANIMATION);

			GamePlayController.instance.isPlayerAlive = false;

			GamePlayController.instance.GameOver();
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == MyTags.COIN_TAG) {
			other.gameObject.SetActive (false);
			GamePlayController.instance.CoinCollected();
			SoundManager.instance.PlayCoinSound();
		}
	}
}
