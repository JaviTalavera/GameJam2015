using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour {

    public Vector3 direction;
    private int damage;
    public float speed;
    public GameObject ball;
    private bool markToDestroy = false;

    public AudioSource[] audioSources;

	// Use this for initialization
	void Start () {
        
        Destroy(gameObject, 5.0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (direction != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, direction, Time.deltaTime * speed);
            //transform.Translate(direction * Time.deltaTime * speed);
        }

        if (markToDestroy)
        {
            DestroyImmediate(ball);
            if (!audioSources[0].isPlaying)
                DestroyImmediate(gameObject);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DamageDebuff db = other.gameObject.AddComponent<DamageDebuff>();
            db.Execute(damage);
            audioSources[0].Play();
            markToDestroy = true;
        }
    }

    public void SetPlayerTarget(Vector3 pe_direction)
    {
        direction = pe_direction;
    }

    public void SetEnemyDamage(int pe_enemyDamage)
    {
        damage = pe_enemyDamage;
    }
}
