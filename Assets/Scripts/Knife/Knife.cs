using UnityEngine;
using System.Collections;

public class Knife : MonoBehaviour {

	// Velocidad de rotacion
	public float RSpeed;

	// Player
	public GameObject Player;

	// Tiempo de vida del cuchillo
	public float LiveTime;

	// Tiempos
	private float tiempo = 0;

	// Use this for initialization
	void Start ()
	{
		if (Player == null)
			Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Incrementar tiempo
		tiempo += Time.deltaTime;

		// Rotacion
		transform.Rotate(Vector3.left * RSpeed);

		// Comprobar tiempo de vida del cuchillo
		if (tiempo >= LiveTime)
			Destruir ();
	}

	// Colisionar
	void OnTriggerEnter(Collider other)
	{
		// Si colisiona con un enemigo hacer daño
		if (other.gameObject.tag == "Enemy")
		{
			//other.gameObject.GetComponent<EnemyStats>().ReceiveDamage(1);
			DamageDebuff db = other.gameObject.AddComponent<DamageDebuff>();
			db.Execute(Player.GetComponent<PlayerStats>().Damage - 1);

		}
		
		if (other.gameObject.tag != "Sarten")
			// Destruir cuchillo
			Destruir ();
	}

	// Destruir cuchillo
	private void Destruir()
	{
		// Particulas

		// Destruir
		Destroy(gameObject);

		// Log
		Debug.Log ("Cuchillo destruido");
	}
}
