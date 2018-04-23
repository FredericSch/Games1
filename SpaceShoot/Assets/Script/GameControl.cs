using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour 
{

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GUIText scoreT;
	private int score;
	private int wave;
	public GUIText waveText;
	public GUIText restartText;
	public GUIText gameoverText;
	private bool gameover;
	private bool restart;

	void Start()
	{
		gameover = false;
		restart = false;
		restartText.text = "";
		gameoverText.text = "";
		wave = 0;
		UpdateWave ();
		score = 0;
		UpdateScore ();
		StartCoroutine (spawnWaves ());
	}

	void Update(){
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R))
			    {

				Application.LoadLevel (Application.loadedLevel);
			}

		
		}
		}

	IEnumerator spawnWaves()
	{
		yield return new WaitForSeconds(startWait);

		while(true)
		{

		for (int i= 0; i<hazardCount ; i++) 
		{
						Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
						Quaternion spawnRotation = Quaternion.identity;
						Instantiate (hazard, spawnPosition, spawnRotation);
			yield return new WaitForSeconds(spawnWait);
		}
			wave++;
			UpdateWave ();
			hazardCount=hazardCount+3;
			yield return new WaitForSeconds (waveWait);

			if(gameover){
				restartText.text = "Press 'R' to lose again";
				restart = true;
				break;
			}
		}

	}

	public void Add (int newScoreValue){
				score += newScoreValue;
				UpdateScore ();
		}
	void UpdateWave(){
		waveText.text = "Wave: " + wave;
	}
	void UpdateScore (){

		scoreT.text = "Score: " + score;
		}
	public void Gameover(){
				if (score <= 10) {
						gameoverText.text = "LOL";		
						gameover = true;
				}
				if (score >= 1000 && score <= 9000) {
						gameoverText.text = "A score of " + score + " that is acceptable, loser.";		
						gameover = true;
				}
				if (score >= 9000) {
						gameoverText.text = "ITS OVER 9000!";		
						gameover = true;
				}
				if (wave >= 100 && score <= 999) {
						gameoverText.text = "Achievement unlocked: Suvrivalist.";
						gameover = true;
				}
				if (score <= 999 && score >= 11) {
						gameoverText.text = "Only a score of " + score + "? GOOD JOB, LOSER!"; 
						gameover = true;
				}
		}
}
