using UnityEngine;
using System.Collections;

public class PlayerRangeAttack : MonoBehaviour {

	// Fuerza con la que se lanza el cuchillo
	public float force;
	public float inclinacion;
	public AudioClip throwKnife;


	// Thrower
	public Transform thrower;

	// Cuchillo
	public GameObject knife;

	public float cooldown;
	private float time2attack;
	public float Esperar;

	// Use this for initialization
	void Start ()
	{
		time2attack = 0;
		// Obtener thrower
		if (thrower == null)
			thrower = GameObject.Find ("KnifeThrower").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Click izquierdo
		/*if (Input.GetMouseButtonDown (0)) {
			if (time2attack <= 0) {
				time2attack = cooldown;
				ThrowKnife ();
			}
		}*/
		time2attack -= Time.deltaTime;
	}

	

	// Lanzar cuchillo
	public void ThrowKnife ()
	{
		if (time2attack <= 0) {
			time2attack = cooldown;
			// DEBUG -- Esperar
			GetComponent<Animator> ().SetBool ("throw", true);
			StartCoroutine ("Wait");
		}
	}
	
	// DEBUG: tiempo
	IEnumerator Wait()
	{
		// Esperar
		yield return new WaitForSeconds (Esperar);

		// Random
		float r = Random.Range (0.0f, 25.0f);
		
		// Rotacion
		Quaternion rot = thrower.rotation;
		rot.x = r;
		
		// Instanciar cuchillo
		GameObject knifeClone = (GameObject)Instantiate(knife, thrower.position, rot);
		Physics.IgnoreCollision(knifeClone.GetComponent<Collider>(), GetComponent<Collider>());
		Physics.IgnoreCollision(knifeClone.GetComponent<Collider>(), GameObject.Find("Sarten").GetComponent<Collider>());
		
		// Fuerza
		Vector3 lanzamiento = transform.forward;
		lanzamiento.y = inclinacion;
		
		knifeClone.GetComponent<Rigidbody> ().AddForce (lanzamiento * force);
		GetComponent<Animator> ().SetBool ("throw", false);

		GetComponent<AudioSource>().clip = throwKnife;
		GetComponent<AudioSource>().Play ();
	}
}
