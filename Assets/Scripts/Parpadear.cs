using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Parpadear : MonoBehaviour {

	public float time_enabled;
	public float time_disabled;

	private float _time_enabled = 0;
	private float _time_disabled = 0;

	public bool Enabled = true;

	public string txt;

	// Use this for initialization
	void Start ()
	{
		txt = gameObject.GetComponentInChildren<Text> ().text;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Enabled)
			_time_enabled += Time.deltaTime;
		else
			_time_disabled += Time.deltaTime;

		// Si se ha cumplido el tiempo habilitado -> Deshabilitar
		if (_time_enabled >= time_enabled)
		{
			// Establecer a 0
			_time_enabled = 0;

			// Deshabilitar
			gameObject.GetComponentInChildren<Text>().text = "";
			Enabled = false;
		}

		// Si se ha cumplido el tiempo habilitado -> Habilitar
		if(_time_disabled >= time_disabled)
		{
			// Establecer a 0
			_time_disabled = 0;
			
			// Deshabilitar
			gameObject.GetComponentInChildren<Text>().text = txt;
			Enabled = true;
		}
	}
}
