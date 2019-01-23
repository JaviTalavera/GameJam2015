using UnityEngine;
using System.Collections;

public class TrapHoney : TrapMaster {

	override
	public void Execute (GameObject other) {
		if (other.GetComponent<HoneyDebuff> () == null) {
			HoneyDebuff buff = other.AddComponent<HoneyDebuff> ();
			buff.Execute (tAttr.debuff, 2f);
		}
	}
}
