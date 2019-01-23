using UnityEngine;
using System.Collections;

public class HealthPoints : MonoBehaviour {

    public GameObject[] healthPoints;
    private int actualHealthPoints;
    private Transform anchorCanvas;

    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {
        this.transform.SetAsLastSibling();
	}
	
	// Update is called once per frame
	void Update () {
        if (anchorCanvas != null)
        {
            Vector3 w_cameraPosition = Camera.main.WorldToScreenPoint(anchorCanvas.position);
            transform.position = w_cameraPosition;
        }
	}

    public void SetAnchorCanvas(Transform pe_anchorCanvas)
    {
        anchorCanvas = pe_anchorCanvas;
    }

    public void SetInitialHealthPoints(int pe_initialHealthPoints)
    {
        for (int i = 0; i < pe_initialHealthPoints; i++)
        {
            healthPoints[i].gameObject.SetActive(true);
            actualHealthPoints++;
        }
    }

    public void UpdateHealthPoints(int pe_contDamage)
    {
        int w_contDamage = pe_contDamage;
        for (int i = actualHealthPoints - 1; i >= 0 && w_contDamage > 0; i--)
        {
            healthPoints[i].gameObject.SetActive(false);
            actualHealthPoints--;
            w_contDamage--;
        }
    }

}
