using UnityEngine;
using System.Collections;

public class TrapFire : TrapMaster {

	public GameObject fire;

	override
	public void Execute (GameObject other) {
		Instantiate (fire, transform.position, fire.transform.rotation);
		DamageDebuff buff = other.AddComponent<DamageDebuff> ();
		buff.Execute (tAttr.damage);
	}
}
