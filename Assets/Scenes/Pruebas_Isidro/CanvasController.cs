using UnityEngine;
using System.Collections;

public class CanvasController : MonoBehaviour {

    public GameObject pnl_Continue;
    public GameObject pnl_Options;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.anyKeyDown)
        {
            pnl_Continue.SetActive(false);
            pnl_Options.SetActive(true);
			//PlayerPrefs.DeleteAll();
        }
	}
}
