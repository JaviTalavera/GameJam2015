using UnityEngine;
using System.Collections;

public class EnemyType3 : EnemyBase
{
    public GameObject[] skills;
    public float Esperar;

    protected override void Awake()
    {
        base.Awake();
    }
    // Use this for initialization
    protected override void Start()
    {
        nameType = "EnemyType3_";
        base.Start();
        enemyAgent.speed = enemyStats.Speed;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    // Update is called once per frame
    /*void Update()
    {

    }*/

    protected override void Movement()
    {
        //StopCoroutine("ThrowSkill");
        GetComponent<Animator>().SetBool("attack", false);
        base.Movement();
    }

    protected override void Attack()
    {
        if (!GetComponent<Animator>().GetBool("attack"))
            base.Attack();
    }

    /*void ThrowSkill()
    {
        GameObject ob_hit = Instantiate(skills[0], thrower.transform.position, Quaternion.identity) as GameObject;
        ob_hit.transform.parent = transform;
        ob_hit.gameObject.name = "Hit";
        HitController w_shootControler = ob_hit.GetComponent<HitController>();
        w_shootControler.SetEnemyDamage(enemyStats.Damage);
    }*/
    IEnumerator ThrowSkill()
    {
        // Realizar en animación
        while (true)
        {
            GetComponent<Animator>().SetBool("attack", true);
            GameObject ob_hit = Instantiate(skills[0], thrower.transform.position, Quaternion.identity) as GameObject;
            ob_hit.transform.parent = thrower.transform;
            ob_hit.gameObject.name = "Punck";
            HitController w_shootControler = ob_hit.GetComponent<HitController>();
            w_shootControler.SetEnemyDamage(enemyStats.Damage);
            StartCoroutine("Wait");

            yield return new WaitForSeconds(3.0f);
            if (actualState != EnemyStates.Attack)
                break;
        }
    }

    IEnumerator Wait()
    {
        // Esperar
        yield return new WaitForSeconds(Esperar);

        GetComponent<Animator>().SetBool("attack", false);
    }

    protected override void StarAttack()
    {
        StartCoroutine("ThrowSkill");
    }
}
