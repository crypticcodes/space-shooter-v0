using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText waveCountText;

	private int score;
	private bool gameOver;
	private bool restart;
	private int waves;
	private int level;

	void Start ()
	{
		score = 0;
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		waves = 0;
		level = 0;
		UpdateWaveText ();
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			waves++;
			LevelSettings levelSettings = LevelSettings.getLevelSettings (level);
			for (int i = 0; i < levelSettings.hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (levelSettings.spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			UpdateWaveText ();

			if (gameOver)
			{
				restartText.text = "Destroy or avoid the asteroids to survive\n" + "Use <arrow> keys to move the spaceship\n" + "Use <space> key to fire at the asteroids\n" + "'R' for restart";
				restart = true;
				break;
			}
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;	
		level = (int)(score * 1.0 / 50.0);
		UpdateScore ();
	}

	public void GameOver(){
		gameOverText.text =  "Game Over!";
		gameOver = true;
	}

	public void Restart() {
	}
		
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score + "\nLevel: " + level;
	}

	void UpdateWaveText () {
		waveCountText.text = "Waves:" + waves;
	}
		


}