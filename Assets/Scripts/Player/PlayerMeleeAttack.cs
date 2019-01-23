using UnityEngine;
using System.Collections;

public class PlayerMeleeAttack : MonoBehaviour {

	// GameObject que va anclado en la animacion
	public GameObject KnifeMelee;

	public float cooldown;
	private float time2Attack;

	// Segundos a esperar
	public float Esperar;

	// Use this for initialization
	void Start ()
	{
		time2Attack = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Click derecho
		//if (Input.GetMouseButtonDown (1)) {
		//		Attack ();
		//		time2Attack = cooldown;
		//	}
		//}
		time2Attack -= Time.deltaTime;
	}

	// Atacar
	public bool Attack()
	{
		if (time2Attack <= 0) {
			time2Attack = cooldown;
			
			// Comenzar a atacar
			KnifeMelee.GetComponent<KnifeMelee> ().BeginAttack ();
			GetComponent<Animator> ().SetBool ("attack", true);
			
			// DEBUG -- Esperar
			StartCoroutine ("Wait");
			return true;
		}
		return false;

	}

	// DEBUG: tiempo
	public IEnumerator Wait()
	{
		// Esperar
		yield return new WaitForSeconds (Esperar);

		GetComponent<Animator> ().SetBool ("attack", false);
        KnifeMelee.GetComponent<KnifeMelee>().EndAttack();

	}
}
