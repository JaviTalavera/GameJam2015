using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ManageRanking : MonoBehaviour
{
	private string name1 = "";
	private int score1 = 0;

	private string name2 = "";
	private int score2 = 0;

	private string name3 = "";
	private int score3 = 0;

	private int puesto = -1;
	private string namePuesto = "";

	void Start()
	{

	}

	void Update()
	{
		if(Input.GetKey(KeyCode.F))
		{
			ObtenerScore();
			GuardarScore(GlobalState.score);

			Application.LoadLevel(2);
		}
	}

	void Awake()
	{
		DontDestroyOnLoad (gameObject);
	}

	public void ObtenerScore()
	{
		if (PlayerPrefs.HasKey ("name1"))
		{
			name1 = PlayerPrefs.GetString("name1");
			score1 = PlayerPrefs.GetInt("score1");
		}

		if (PlayerPrefs.HasKey ("name2"))
		{
			name2 = PlayerPrefs.GetString("name2");
			score2 = PlayerPrefs.GetInt("score2");
		}

		if (PlayerPrefs.HasKey ("name3"))
		{
			name3 = PlayerPrefs.GetString("name3");
			score3 = PlayerPrefs.GetInt("score3");
		}
	}

	public void GuardarScore(int sc)
	{
		//sc = score1 + 1; // DEBUG -- Borrar

		// Comprobar con puesto 1
		if(sc > score1)
		{
			puesto = 1;
			namePuesto = "name1";

			// Mover los otros
			if(name2 != "")
			{
				name3 = name2;
				PlayerPrefs.SetString("name3", name3);

				score3 = score2;
				PlayerPrefs.SetInt("score3", score3);
			}

			if(name1 != "")
			{
				name2 = name1;
				PlayerPrefs.SetString("name2", name2);

				score2 = score1;
				PlayerPrefs.SetInt("score2", score2);
			}

			PlayerPrefs.SetString("name1", "");
			name1 = "";

			PlayerPrefs.SetInt("score1", sc);
			score1 = sc;
		}

		// Comprobar con puesto 2
		else if(sc > score2)
		{
			puesto = 2;
			namePuesto = "name2";

			// Mover los otros
			if(name2 != "")
			{
				name3 = name2;
				PlayerPrefs.SetString("name3", name3);
				
				score3 = score2;
				PlayerPrefs.SetInt("score3", score3);
			}
			
			PlayerPrefs.SetString("name2", "");
			name2 = "";
			
			PlayerPrefs.SetInt("score2", sc);
			score2 = sc;
		}

		// Comprobar con puesto 3
		else if(sc > score3)
		{
			puesto = 3;
			namePuesto = "name3";

			PlayerPrefs.SetString("name3", "");
			name3 = "";
			
			PlayerPrefs.SetInt("score3", sc);
			score3 = sc;
		}
	}

	void GuardarNombre()
	{
		// Obtener nombre
		string nombre = GameObject.Find ("tbNombre").GetComponent<InputField> ().text;

		if (nombre != "")
		{
			switch(puesto)
			{
				case 1: name1 = nombre; 
						PlayerPrefs.SetString ("name1", nombre);break;

				case 2: name2 = nombre;
						PlayerPrefs.SetString ("name2", nombre); break;

				case 3: name3 = nombre;
						PlayerPrefs.SetString ("name3", nombre); break;
			}

			puesto = -1;

			Application.LoadLevel (2);
		}
	}

	void Menu()
	{
		//GlobalState.InitGame ();

		GlobalState.round = 0;
		GlobalState.score = 0;
		GlobalState.lifes = 4;
		GlobalState.coins = 15;
		GlobalState.time = 15f;
		GlobalState.nEnemies = 5;

		Destroy (gameObject);
		Application.LoadLevel (0);
	}

	void OnLevelWasLoaded (int level)
	{
		// Abrir ranking
		if (level == 2)
		{
			gameObject.GetComponent<GlobalState>().enabled = false;
			gameObject.GetComponent<SelectTrap>().enabled = false;

			GameObject.Find ("txtNombre1").GetComponent<Text>().text = name1;
			GameObject.Find ("txtScore1").GetComponent<Text>().text = score1.ToString();

			// No mostrar
			if(score1 == 0)
			{
				GameObject.Find ("txtNombre1").SetActive(false);
				GameObject.Find ("txtScore1").SetActive(false);
			}

			GameObject.Find ("txtNombre2").GetComponent<Text>().text = name2;
			GameObject.Find ("txtScore2").GetComponent<Text>().text = score2.ToString();

			// No mostrar
			if(score2 == 0)
			{
				GameObject.Find ("txtNombre2").SetActive(false);
				GameObject.Find ("txtScore2").SetActive(false);
			}

			GameObject.Find ("txtNombre3").GetComponent<Text>().text = name3;
			GameObject.Find ("txtScore3").GetComponent<Text>().text = score3.ToString();

			// No mostrar
			if(score3 == 0)
			{
				GameObject.Find ("txtNombre3").SetActive(false);
				GameObject.Find ("txtScore3").SetActive(false);
			}

			// Guardar nombre
			if(puesto > 0)
			{
				// Guardar
				GameObject.Find("btGuardar").GetComponent<Button>().onClick.AddListener (() => 
				                        { GuardarNombre();});

				// Ocultar continuar
				GameObject.Find ("btContinuar").SetActive(false);
			}
			else
			{
				// Ocultar guardar
				GameObject.Find ("tbNombre").SetActive(false);
				GameObject.Find ("lblNombre").SetActive(false);
				GameObject.Find ("btGuardar").SetActive(false);

				// Mostrar continuar
				//GameObject.Find ("btContinuar").SetActive(true);

				GameObject.Find("btContinuar").GetComponent<Button>().onClick.AddListener (() => 
				                                                                         { Menu();});
			}
		}
	}
}