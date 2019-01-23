using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour {

    public bool endWayPoint = false;
    public WayPoint nextWayPoint;
    public WayPoint[] wayPoints;
	// Use this for initialization
	void Start () {
        if (!endWayPoint && nextWayPoint == null && wayPoints.Length == 0)
        {
            Debug.LogError("Error en WayPoint. Un WayPoint que no sea final no puede no tener un nextWayPoint");
        }
        ChangeNextWayPoint();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void ChangeNextWayPoint()
    {
        if (wayPoints.Length > 0)
        {
            int w_nextWayPoint = (int)Random.Range(0, wayPoints.Length);
            nextWayPoint = wayPoints[w_nextWayPoint];
        }
    }

	void OnDrawGizmos () {
		if (wayPoints.Length > 0) {
			foreach(WayPoint wp in wayPoints) {
				Gizmos.color = Color.green;
				Gizmos.DrawLine (transform.position, wp.transform.position);
			}
		}

		else if(nextWayPoint){
			Gizmos.color = Color.green;
			Gizmos.DrawLine (transform.position, nextWayPoint.transform.position);
		}
	}
}
