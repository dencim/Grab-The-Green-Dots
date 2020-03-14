using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Main : MonoBehaviour {

	public Text scoreText;
	public static int score = 0;
	public int highScore = 0;
	public GameObject circle;
	public Button retryButton;
	public Button shareButton;
	public Text highScoreText;
	public bool playedAnim;
	public GameObject player;
	public GameObject anchor;
	float timer = 0;
	float timer1 = 1;
	public GameObject tapToStart;

	public Text stats;
	public GameObject statsUI;
	public GameObject statsButton;
	public static float circlesCollected;
	public static int totalClicks;
	public static float totalDeaths;
	public static float kd;

	public AudioClip click;
	public AudioClip click2;
	public AudioClip click3;
	public AudioClip collectedDotSound;
	public static bool collectedDot;

	public GameObject adUi;
	public GameObject themeUi;

	bool newHighScore;


	void OnEnable(){

		Load ();
		themeUi.SetActive(false);

	}

	// Use this for initialization
	void Start () {

		highScoreText.gameObject.SetActive(false);
		statsButton.gameObject.SetActive(false);
	
	}
	
	// Update is called once per frame
	void Update () {

		if(collectedDot == true){
			audio.PlayOneShot(collectedDotSound);
			collectedDot = false;
		}



		scoreText.text = score.ToString();


		if(Player.playerAlive == false && playedAnim == false){

			if(Ads.adCountdown != 0 || Advertisement.IsReady() == false){
			//if(Ads.adCountdown > 0){

				if(score > highScore || newHighScore == true){
					highScoreText.text = "New High Score!";
					highScore = score;
					newHighScore = true;
				}
				else{
					highScoreText.text = "High Score: " + highScore.ToString();
				}
				
				timer += 1 * Time.deltaTime;
				
				
				if(timer > 1){
					scoreText.gameObject.animation.Play("AfterDeathScoreDisplay");
					circle.gameObject.animation.Play("DeadUiCircle");
					shareButton.gameObject.animation.Play("ShareIn");
					retryButton.gameObject.animation.Play("RetryIn");
					highScoreText.gameObject.SetActive(true);
					statsButton.gameObject.SetActive(true);
					audio.PlayOneShot(click);
					playedAnim = true;
					themeUi.SetActive(true);
				}
			}
			else{

				if(Player.playerAlive == false){
					timer1 -= 1 * Time.deltaTime;
				}


				if(timer1 < 0){
					adUi.gameObject.SetActive(true);
				}
				//adUi.gameObject.SetActive(true);
			}



		}

		if(Movement.gameStarted == false){

			if(tapToStart.gameObject.animation.isPlaying){

			}
			else{
				tapToStart.gameObject.animation.Play("Tap To Start");
			}
		}
		else{
			tapToStart.gameObject.SetActive(false);
		}
	
	}

	public void Retry(){

		scoreText.gameObject.animation.Play("BackToScoreDisplay");
		circle.gameObject.animation.Play("AliveUiCircle");
		shareButton.gameObject.animation.Play("ShareOut");
		retryButton.gameObject.animation.Play("RetryOut");
		highScoreText.gameObject.SetActive(false);
		tapToStart.gameObject.SetActive(true);
		statsButton.gameObject.SetActive(false);
		audio.PlayOneShot(click3);
		Movement.startTimer = 0;
		themeUi.SetActive(false);

		Player.playAnimAfterDeath = true;
		Player.playerAlive = true;
		Movement.gameStarted = false;
		playedAnim = false;
		timer = 0;
		timer1 = 1;
		score = 0;

		newHighScore = false;

		player.transform.localPosition = new Vector2(2, 0);

		player.transform.localScale = new Vector2(0.3f, 0.3f);
		anchor.transform.eulerAngles = new Vector3(0, 0, 90);



	}

	public void ShowStats(){

		audio.PlayOneShot(click2);
		statsUI.gameObject.SetActive(true);
		kd = circlesCollected / totalDeaths;
		stats.text = "Total Clicks: " + totalClicks + "\nTotal Dots Collected: " + circlesCollected + "\nTotal Death's: " + totalDeaths + "\nAverage Score: " + kd ;

	}

	public void CloseStats(){
		audio.PlayOneShot(click2);
		statsUI.gameObject.SetActive(false);
	}




	void OnApplicationQuit(){
		Save ();
	}
	void OnApplicationPause(){
		Save ();
	}
	
	void OnDisable(){
		Save();
	}
	
	public void Save(){
		
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerinfo.dat");
		
		
		PlayerData data = new PlayerData();
		data.highScore = highScore;
		data.circlesCollected = circlesCollected;
		data.totalClicks = totalClicks;
		data.totalDeaths = totalDeaths;
		data.kd = kd;
		data.themeName = Theme.themeName;
		
		bf.Serialize(file, data);
		file.Close();
	}
	
	public void Load(){
		
		if(File.Exists(Application.persistentDataPath + "/playerinfo.dat")){
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerinfo.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();
			
			highScore = data.highScore;
			circlesCollected = data.circlesCollected;
			totalClicks = data.totalClicks;
			totalDeaths = data.totalDeaths;
			kd = data.kd;
			Theme.themeName = data.themeName;

			
		}
	}



}


[Serializable]
class PlayerData{
	
	public int highScore;
	public float circlesCollected;
	public int totalClicks;
	public float totalDeaths;
	public float kd;
	public string themeName;

	
}
