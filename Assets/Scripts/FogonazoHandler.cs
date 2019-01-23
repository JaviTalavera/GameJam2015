using UnityEngine;
using System.Collections;

public class FogonazoHandler : MonoBehaviour {

	public Light light;
	
	// Update is called once per frame
	void Update () {
		light.intensity -= 0.01f;
		if (light.intensity <= 0f)
			Destroy (gameObject);
	}
}
