using UnityEngine;
using System.Collections;

public class GameLevelControl : MonoBehaviour {
	
	public enum State {Running, NotRunning};
	
	public State currentState;
	
	public int level = 0;
	
	public MushroomSpawner shroomSpawner;
	public CentipedeSpawner pedeSpawner;
	public PlayerSpawner playerSpawner;
	
	public float mushroomSpawnRateDecrease = 0.1f;
	public float pedeSpawnRateDecrease = 0.1f;
	
	public float mushroomMinSpawnRate = 0.8f;
	public float pedeMinSpawnRate = 1.0f;
	public int pedeSpawnTotalIncrease = 2;
	
	private bool canBeginLevel = false;
	
	// Use this for initialization
	void Start () {
		canBeginLevel = true;
		Time.timeScale = 1.0f;
		
		PlayerLifeKeeper.Reset();
		
		currentState = State.NotRunning;
		
		System.DateTime epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
		int timestamp = (int) (System.DateTime.UtcNow - epochStart).TotalSeconds;

		Random.seed = timestamp;
	}
	
	// Update is called once per frame
	void Update () {
		if( canBeginLevel )
		{
			if(Input.GetKeyUp(KeyCode.KeypadEnter))
			{
				BeginLevel();
			}
		}
		else
		{
			if( !pedeSpawner.spawning && (GameObject.Find(pedeSpawner.pede.name) == null) )
			{
				EndLevel(true);
			}
		}
	}
	
	public bool isGameRunning()
	{
		return !canBeginLevel;
	}
	
	public void BeginLevel()
	{
		if( canBeginLevel )
		{
			canBeginLevel = false;
			PrepareLevel();
			
			// Start spawners
			shroomSpawner.spawning = true;
			pedeSpawner.spawning = true;
			
			// Unlock player weapons
			Shoot playerGun = GameObject.Find("Player").transform.FindChild("Shooter").GetComponent<Shoot>();
			playerGun.gunEnabled = true;
			
			currentState = State.Running;
		}
	}
	
	public void EndLevel(bool addScore)
	{
		canBeginLevel = true;
		currentState = State.NotRunning;
		
		// Stop spawners
		shroomSpawner.spawning = false;
		pedeSpawner.spawning = false;
		
		// Lock player gun
		GameObject player = GameObject.Find("Player");
		if( player != null )
		{
			Shoot playerGun = player.transform.FindChild("Shooter").GetComponent<Shoot>();
			playerGun.gunEnabled = false;
		}
		
		if( addScore )
		{
			// Award bonus points for finishing the level
			ScoreKeeper.AddScore(level * 150);
		}
	}
	
	private void PrepareLevel()
	{
		level++;
		
		// Configure mushroom spawner
		shroomSpawner.spawnRate = 3.0f - (level * mushroomSpawnRateDecrease);
		shroomSpawner.spawnCount = 1;
		
		// Configure Centipede spawner
		pedeSpawner.spawnRate = 2.0f - (level * pedeSpawnRateDecrease);
		pedeSpawner.spawnCount = 1;
		pedeSpawner.spawnTotal = 10 + (pedeSpawnTotalIncrease * level);
	
		if( shroomSpawner.spawnRate < mushroomMinSpawnRate )
		{
			shroomSpawner.spawnRate = mushroomMinSpawnRate;
		}
		
		if( pedeSpawner.spawnRate < pedeMinSpawnRate )
		{
			pedeSpawner.spawnRate = pedeMinSpawnRate;
		}
		
		playerSpawner.SpawnPlayer();
		
	}
	
	public void ResetLevel()
	{
		StartCoroutine(ResetLevelPrivate());
	}
	
	private IEnumerator ResetLevelPrivate()
	{
		yield return new WaitForSeconds(4);
		
		EndLevel(false);
		
		foreach( GameObject obj in GameObject.FindGameObjectsWithTag("Enemy") )
		{
			Destroy(obj);
		}
		
		yield return new WaitForSeconds(1);
		
		level--;
		
		BeginLevel();
	}
	
	public void GameOver()
	{
		StartCoroutine(GameOverPrivate());
	}
	
	private IEnumerator GameOverPrivate()
	{
		yield return new WaitForSeconds(4);
		
		EndLevel(false);
		
		int endScore = (int)ScoreKeeper.GetScore();
		GameObject.Find("HighScoreControl").GetComponent<HighScoreControl>().EnterHighScore(endScore);
		
		Application.LoadLevel("HighScoreScene");
	}
	
	
}
