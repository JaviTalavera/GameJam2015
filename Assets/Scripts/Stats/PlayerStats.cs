using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	// Stats basicos
	public int MaxHealth;
	public int Health;
	public float Speed;
	public int Damage;
	public int Coins;

	// Indicador de si esta vivo
	private bool alive = true;

	public bool Alive
	{
		get { return alive;}
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Comprobar si esta vivo
		if (Health == 0)
			alive = false;
		else
			alive = true;

        UpdateHealthPoints();
	}

	// Recibir daño
	public void ReceiveDamage(int damage)
	{
		// Restar vida
		Health -= damage;

		// Comprobar no sea menor de cero
		if (Health < 0)
			Health = 0;

        UpdateEnemyCanvas(damage);
	}

    protected virtual void UpdateEnemyCanvas(int dmg)
    {

    }

    protected virtual void UpdateHealthPoints()
    {

    }
}
