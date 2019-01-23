using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectTrap : MonoBehaviour {

	public Image[] skills;
	public GameObject[] prefabSkills;
	public int[] skillsCost;

	public int selected;

	// Use this for initialization
	void Start () {
		selected = 0;
		skills[selected].color = Color.green;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Mouse ScrollWheel") > 0) {
			if (selected < skills.Length -1) {
				skills[selected].color = Color.white;
				selected++;
				if (GlobalState.coins >= skillsCost[selected])
					skills[selected].color = Color.green;
				else
					skills [selected].color = Color.red;
			}
		}
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			if (selected > 0) {
				skills [selected].color = Color.white;
				selected--;
				if (GlobalState.coins >= skillsCost[selected])
					skills [selected].color = Color.green;
				else
					skills [selected].color = Color.red;
			}
		}
		if (Input.GetMouseButtonDown (0)) {
			if (selected == 0) {
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRangeAttack>().ThrowKnife();
			}
			else if (selected == 1) {
				if (GlobalState.coins >= skillsCost[selected]) {
					if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMeleeAttack>().Attack()) {
						GlobalState.coins -= skillsCost[selected];
					}
				}
			}
			else {
				RaycastHit hit = new RaycastHit();
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray,out hit, 1000)) {
					if (hit.collider.tag == "Ground" &&
					    !hit.collider.gameObject.GetComponent<GroundIndividual>().trapped &&
					    GlobalState.coins >= skillsCost[selected]) {
						GlobalState.coins -= skillsCost[selected];
						GameObject go = Instantiate(prefabSkills[selected],
						                            hit.transform.position + new Vector3(-1f, 0, 1f),
						                            prefabSkills[selected].transform.rotation) as GameObject;
						go.GetComponent<TrapMaster>().gi = hit.collider.gameObject.GetComponent<GroundIndividual>();
						hit.collider.gameObject.GetComponent<GroundIndividual>().trapped = true;

					}
				}
			}
		}
	}
}
