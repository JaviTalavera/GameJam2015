using UnityEngine;
using System.Collections;

public class DamageDebuff : MonoBehaviour {

	public void Execute (int damage) {
        GetComponent<PlayerStats>().ReceiveDamage(damage);
		Debug.Log ("DAÑO REALIZADO");
		Destroy (this);
	}
}
