using UnityEngine;
using System.Collections;

public class TrapExplosion : TrapMaster {

	public GameObject explosion;

	override
	public void Execute (GameObject other) {
		GameObject exp = Instantiate (explosion, transform.position, explosion.transform.rotation) as GameObject;
		exp.GetComponent<ExplosionHandler> ().tAttr = GetComponent<TrapAttributtes> ();
		gi.trapped = false;
		Destroy (gameObject);
	}
}
