using UnityEngine;
using System.Collections;

public class ExplosionHandler : MonoBehaviour {

	public TrapAttributtes tAttr;
	public float duration;

	void Start () {
		StartCoroutine ("Die");
	}

	public IEnumerator Die () {
		yield return new WaitForSeconds (duration/2);
		Destroy (gameObject.GetComponent<Collider> ());
		yield return new WaitForSeconds (duration/2);
		Destroy (gameObject);
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Enemy") {
			DamageDebuff buff = other.gameObject.AddComponent<DamageDebuff>();
			buff.Execute(tAttr.damage);
		}
	}
}
