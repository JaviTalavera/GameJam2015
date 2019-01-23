using UnityEngine;
using System.Collections;

public class PanelOptions : MonoBehaviour {


    public void OnCLickPlay()
    {
		//PlayerPrefs.DeleteAll ();
        Application.LoadLevel(1);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
