using UnityEngine;
using System.Collections;

public class TrapAttributtes : MonoBehaviour {
	public int hits;
	public int damage;
	public int coins;

	public float debuff;
	public float cooldown;
	private float time2Attack;

	void Start () {
		time2Attack = cooldown;
	}

	void FixedUpdate () {
		time2Attack -= Time.fixedDeltaTime;
	}

	public bool CanUse () {
		if (time2Attack <= 0f) {
			time2Attack = cooldown;
			return true;
		}
		return false;
	}
}
