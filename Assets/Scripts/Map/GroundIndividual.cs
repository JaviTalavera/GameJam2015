using UnityEngine;
using System.Collections;

public class GroundIndividual : MonoBehaviour {

	public Color normalColor;
	public bool trapped = false;

	void OnMouseEnter () {
		GetComponent<MeshRenderer> ().material.color = Color.white;
	}

	void OnMouseExit () {
		GetComponent<MeshRenderer> ().material.color = normalColor;
	}
}
