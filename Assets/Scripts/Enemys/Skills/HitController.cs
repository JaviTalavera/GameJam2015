using UnityEngine;
using System.Collections;

public class HitController : MonoBehaviour {


    private int damage;
    private bool markToDestroy = false;
    private AudioSource kickSource;

    void Awake()
    {
        kickSource = GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (markToDestroy && !kickSource.isPlaying)
            DestroyImmediate(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !markToDestroy)
        {
            DamageDebuff db = other.gameObject.AddComponent<DamageDebuff>();
            db.Execute(damage);
            kickSource.Play();
            markToDestroy = true;
        }
    }

    public void SetEnemyDamage(int pe_enemyDamage)
    {
        damage = pe_enemyDamage;
    }
}
