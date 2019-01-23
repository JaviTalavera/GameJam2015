using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    private UnityEngine.AI.NavMeshAgent enemyAgent;
    private EnemyStats enemyStats;
    public WayPoint wayPointToMove;
    private GameObject playerTarget;

    public float rank = 1.5f;
    public bool haveTarget = false;
    //public float distance;

    void Awake()
    {
        enemyAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemyStats = GetComponent<EnemyStats>();
    }
	// Use this for initialization
	void Start () {
	
	}

    void FixedUpdate()
	{
		enemyAgent.speed = enemyStats.Speed;
        if (!haveTarget)
        {
            if (!InRank())
            {
                if (CheckDistances())
                    MoveEnemyToNextPoint();
            }
            else
            {
                if (!wayPointToMove.endWayPoint)
                {
                    MoveEnemyToNextPoint();
                }
                else
                {
                    GlobalState.subsLife();
                    enemyStats.KillEnemy();
                    //DestroyImmediate(gameObject);
                }
            }
        }
        else
        {
            RotateEnemy();
        }
    }

	// Update is called once per frame
	void Update () {
        //distance = Vector3.Distance(transform.position, wayPointToMove.transform.position);
	}

    public void StopMovenment()
    {
        enemyAgent.Stop();
    }

    public void ResumeMovenment()
    {
        /*if (playerTarget)
            SetEnemyDestination(playerTarget.transform.position);*/
        enemyAgent.Resume();
    }

    public void MoveToTarget(Vector3 pe_targetPosition, GameObject pe_playerTarget)
    {
        haveTarget = true;
        playerTarget = pe_playerTarget;
        SetEnemyDestination(pe_targetPosition);
    }

    public void ResumeToWayPoint()
    {
        haveTarget = false;
        SetEnemyDestination(wayPointToMove.transform.position);
        ResumeMovenment();
    }

    public void SetWayPointToMove(WayPoint pe_wayPointToMove)
    {
        wayPointToMove = pe_wayPointToMove;
        SetEnemyDestination(wayPointToMove.transform.position);
    }

    bool InRank()
    {
        float w_distance = Vector3.Distance(transform.position, wayPointToMove.transform.position);
        return w_distance < rank;
    }
    void MoveEnemyToNextPoint()
    {
        wayPointToMove = wayPointToMove.nextWayPoint;
        wayPointToMove.ChangeNextWayPoint();
        SetEnemyDestination(wayPointToMove.transform.position);
    }

    void SetEnemyDestination(Vector3 pe_destination)
    {
        Vector3 w_destination = new Vector3(pe_destination.x,
                                            transform.position.y,
                                            pe_destination.z);
        enemyAgent.SetDestination(w_destination);
    }

    bool CheckDistances()
    {
        if (wayPointToMove.endWayPoint)
            return false;

        float w_distanceToWayPoint, w_distanceToNextWayPoint;
        w_distanceToWayPoint = Vector3.Distance(transform.position,wayPointToMove.transform.position);
        w_distanceToNextWayPoint = Vector3.Distance(transform.position, wayPointToMove.nextWayPoint.transform.position);

        if (w_distanceToNextWayPoint < w_distanceToWayPoint)
            return true;

        return false;
    }

    void RotateEnemy()
    {
        float angulo = Vector3.Angle(playerTarget.transform.position - transform.position, transform.forward);
        if (angulo < 2.0f)
        {
            return;
        }
        else
        {
            Quaternion rot = Quaternion.LookRotation(playerTarget.transform.position - transform.position, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 2.5f);
        }
    }
}
