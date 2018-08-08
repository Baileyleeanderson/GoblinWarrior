using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;
	[SerializeField]
	private AudioSource coinAudioSource;
	[SerializeField]
	private AudioClip[] fx;

	void Awake () {
		MakeInstance();
	}

	void Start () {
		
	}
	
	void MakeInstance() {
		if (instance == null) {
			instance = this;
		}
		else if (instance != null) {
			Destroy (gameObject);
		}
	}

	public void PlayCoinSound() {
		coinAudioSource.PlayOneShot(fx[0]);
	}
	
	public void PlayAttackSound() {
		coinAudioSource.PlayOneShot(fx[1]);
	}
	
	public void PlayJumpSound() {
		coinAudioSource.PlayOneShot(fx[2]);
	}
	
	public void PlayEnemyDeadSound() {
		coinAudioSource.PlayOneShot(fx[3]);
	}
}
