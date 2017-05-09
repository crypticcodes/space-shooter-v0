using System.Collections;
using System.Collections.Generic;


public class LevelSettings {

	public int hazardCount;
	public float spawnWait;



	public static LevelSettings getLevelSettings(int level) {
		LevelSettings levelSettings = new LevelSettings ();
		switch (level) {
		case 0: 
			levelSettings.hazardCount = 2;
			levelSettings.spawnWait = 1.5f;
			return levelSettings;
		case 1:
			levelSettings.hazardCount = 3;
			levelSettings.spawnWait = 1.2f;
			return levelSettings;
		case 2:
			levelSettings.hazardCount = 4;
			levelSettings.spawnWait = 1.0f;
			return levelSettings;
		case 3: 
			levelSettings.hazardCount = 6;
			levelSettings.spawnWait = 0.8f;
			return levelSettings;
		case 4: 
			levelSettings.hazardCount = 8;
			levelSettings.spawnWait = 0.5f;
			return levelSettings;
		default: 
			levelSettings.hazardCount = 10;
			levelSettings.spawnWait = 0.3f;
			return levelSettings;
		}
	}
}
