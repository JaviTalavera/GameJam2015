using UnityEngine;
using System.Collections;

public class KnifeMelee : MonoBehaviour {

	// Indica si esta atacando
	public bool Atacando;

	// Numero de enemigos que puede golpear
	public int Golpes;
	private int _golpes = 0;

	// Lista de enemigos golpeados
	public ArrayList enemigos = new ArrayList();

	// Player
	public GameObject Player;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

	// Use this for initialization
	void Start ()
	{
		// Buscar player
		if (Player == null)
			Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void BeginAttack()
	{
		// Inicializar
		Atacando = true;
		_golpes = 0;
	}

	public void EndAttack()
	{
		// Finalizar
		Atacando = false;
		enemigos = new ArrayList ();
	}

	// Colisionar
	void OnTriggerStay(Collider other)
	{
		// Si esta atacando y no se han dado el maximo de golpes
		if (Atacando && _golpes < Golpes)
		{
			// Colision con enemigo
			if (other.gameObject.tag == "Enemy")
			{
				// Buscar en la lista de enemigos para no golpear al mismo mas de una vez
				if(!enemigos.Contains(other.gameObject))
				{
					// Añadir a la lista de enemigos
					enemigos.Add(other.gameObject);

					// Incrementar golpes
					_golpes++;

					// Daño
					DamageDebuff db = other.gameObject.AddComponent<DamageDebuff> ();
					db.Execute (Player.GetComponent<PlayerStats>().Damage);
                    audioSource.Play();

					// Debug
					Debug.Log("Golpe melee " + _golpes);
				}
			}
		}
	}
}
