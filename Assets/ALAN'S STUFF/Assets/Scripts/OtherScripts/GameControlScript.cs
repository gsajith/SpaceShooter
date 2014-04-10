using UnityEngine;
using System.Collections;

public class GameControlScript : MonoBehaviour {

	static public bool select = false;
	static public GameObject selectedPlanet = null;

	static public int playerMP = 0;
	static public int playerMoney = 0;
	static public int playerMineral = 0;

	static public int playerMPAdd = 1;
	static public int playerMoneyAdd = 1;
	static public int playerMineralAdd = 1;


	static public int enemyMP = 0;
	static public int enemyMoney = 0;
	static public int enemyMineral = 0;
	
	static public int enemyMPAdd = 1;
	static public int enemyMoneyAdd = 1;
	static public int enemyMineralAdd = 1;

	static public int currentPlayer = 1;

	static public bool turnOver = false;

	static public int homeShip = 0;
	static public int goHome = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetInt ("CurrentPlayer", currentPlayer);
	}

	static public void updatePlayerRes()
	{
		playerMP += playerMPAdd;
		playerMoney += playerMoneyAdd;
		playerMineral += playerMineralAdd;
		}

	static public void updateEnemyRes()
	{
		enemyMP += enemyMPAdd;
		enemyMoney += enemyMoneyAdd;
		enemyMineral += enemyMineralAdd;
	}

}
