using UnityEngine;
using System.Collections;

public class TrapMaster : MonoBehaviour {

	protected TrapAttributtes tAttr;
	public GroundIndividual gi;

	void Start () {
		tAttr = GetComponent<TrapAttributtes> ();
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Enemy") {
			if (tAttr.CanUse()) {
				Execute(other.gameObject);
				tAttr.hits--;
				if (tAttr.hits == 0) {
					gi.trapped = false;
					Destroy (gameObject);
				}
			}
		}
	}

	virtual
	public void Execute (GameObject other) {}

}
