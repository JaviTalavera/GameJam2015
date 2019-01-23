using UnityEngine;
using System.Collections;

public class EnemyType0 : EnemyBase
{

    protected override void Awake()
    {
        base.Awake();
    }
    // Use this for initialization
    protected override void Start()
    {
        nameType = "EnemyType0_";
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected override void Movement()
    {
        base.Movement();
    }

    protected override void Attack()
    {
        base.Attack();
    }
}
