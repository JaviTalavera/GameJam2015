using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GlobalState : MonoBehaviour {

	public static int round = 0;
	public static int score = 0;
	public static int lifes = 4;
	public static int coins = 15;
	public PlayerStats ps;
	public static float time = 15f;
	private float time2Start;
	public static int nEnemies = 5;
	public float tEnemies = 1;
	public bool gameStarted = false;
	public int incrementBetweenWaves;

	public Text scoreText;
	public GameObject time2StartText;
	public Text coinsText;

	public Image hpbar;

	public static void addScore (int score) {
		GlobalState.score += score;
	}

	public static void addCoins (int coins) {
		GlobalState.coins += coins;
	}

	public static void subsLife () {
		GlobalState.lifes--;
		GameObject.Find("Lifes").transform.GetChild(GlobalState.lifes).gameObject.SetActive(false);

        if (lifes == 0) {
			// Obtener administracion de ranking
			ManageRanking mr = GameObject.Find("GameState").GetComponent<ManageRanking>();

			mr.ObtenerScore();
			mr.GuardarScore(GlobalState.score);

			Application.LoadLevel(2);
		}
	}

	void Start () {
		time2Start = time;
		//Cursor.visible = false;
		ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats> ();
	}

	void FixedUpdate () {
		if (time2Start <= 0) {
			gameStarted = true;
			GameObject.Find ("pr_InitialWayPoint").GetComponent<EnemyGeneration> ().StartWave (nEnemies, tEnemies);
			time2StartText.SetActive(false);
			time2Start = nEnemies + 15;
			nEnemies += incrementBetweenWaves;
		} else if (time2Start <= 10 && time2Start >= 0 && gameStarted) { 
			time2StartText.SetActive(true);
			time2Start -= Time.fixedDeltaTime;
			time2StartText.GetComponent<Text>().text = time2Start.ToString("F0");
		} else {
			time2Start -= Time.fixedDeltaTime;
			time2StartText.GetComponent<Text>().text = time2Start.ToString("F0");
		}
		coinsText.text = coins.ToString ();
		scoreText.text = score.ToString ();

		hpbar.fillAmount = (float)ps.Health / (float)ps.MaxHealth;
	}

	public static void InitGame () {
		Debug.Log ("Iniciando nuevo juego");
		round = 0;
		score = 0;
		lifes = 4;
		coins = 15;
		time = 15f;
		nEnemies = 5;

		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Trap")) {
			go.GetComponent<TrapMaster>().gi.trapped = false;
			Destroy(go);
		}

		foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy")) {
			DamageDebuff buff = go.AddComponent<DamageDebuff>();
			buff.Execute(1000);
		}

		for (int i = 0; i < 4; i++)
			GameObject.Find("Lifes").transform.GetChild(i).gameObject.SetActive(true);
	}

}
