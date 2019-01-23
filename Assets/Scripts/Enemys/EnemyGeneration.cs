using UnityEngine;
using System.Collections;

public class EnemyGeneration : MonoBehaviour {

    public GameObject[] enemy;
    public WayPoint[] initialsWayPoints;

    private int numEnemys;
    private float timeBetweenEnemys;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && enemy.Length > 0)
        {
            StartWave(1, 1.5f);
        }
	}

    public void StartWave(int pe_numEnemys, float pe_timeBetweenEnemys)
    {
        numEnemys = pe_numEnemys;
        timeBetweenEnemys = pe_timeBetweenEnemys;

        StartCoroutine("InitializeEnemys");
    }

    IEnumerator InitializeEnemys()
    {
        int w_enemy, w_wayPoint;
        int w_contEnemys = 0;
        while (w_contEnemys < numEnemys)
        {
            w_enemy = (int)Random.Range(0, enemy.Length);
            GameObject go_enemy = Instantiate(enemy[w_enemy], transform.position, Quaternion.identity) as GameObject;
            w_wayPoint = (int)Random.Range(0, initialsWayPoints.Length);
            go_enemy.GetComponent<EnemyBase>().setWayPoint(initialsWayPoints[w_wayPoint]);
            w_contEnemys++;

            yield return new WaitForSeconds(timeBetweenEnemys);
        }
    }
}
