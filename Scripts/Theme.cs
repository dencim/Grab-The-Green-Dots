using UnityEngine;
using System.Collections;

public class Theme : MonoBehaviour {

	public Camera camera;
	public GameObject themesUi;

	public static string themeName = "white";
	public AudioClip themeClickSound;

	public Color greenThemeColor;
	public Color redThemeColor;
	public Color yellowThemeColor;
	public Color blueThemeColor;
	public Color pinkThemeColor;

	// Use this for initialization
	void Start () {

		camera.clearFlags = CameraClearFlags.SolidColor;
		themesUi.SetActive(false);

		if(themeName == "white"){
			WhiteTheme();
		}
		else if(themeName == "black"){
			BlackTheme();
		}
		else if(themeName == "red"){
			RedTheme();
		}
		else if(themeName == "green"){
			GreenTheme();
		}
		else if(themeName == "yellow"){
			YellowTheme();
		}
		else if(themeName == "blue"){
			BlueTheme();
		}
		else if(themeName == "pink"){
			PinkTheme();
		}
		else{
			WhiteTheme();
		}
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	public void ShowThemes(){
		themesUi.SetActive(true);
		audio.PlayOneShot(themeClickSound);
	}

	public void CloseTheme(){
		themesUi.SetActive(false);
		audio.PlayOneShot(themeClickSound);
	}

	public void WhiteTheme(){
		camera.backgroundColor = Color.white;
		themeName = "white";
		themesUi.gameObject.SetActive(false);
	}

	public void BlackTheme(){
		camera.backgroundColor = Color.black;
		themeName = "black";
		themesUi.gameObject.SetActive(false);
	}

	public void RedTheme(){
		camera.backgroundColor = redThemeColor;
		themeName = "red";
		themesUi.gameObject.SetActive(false);
	}

	public void GreenTheme(){
		camera.backgroundColor = greenThemeColor;
		themeName = "green";
		themesUi.gameObject.SetActive(false);
	}

	public void YellowTheme(){
		camera.backgroundColor = yellowThemeColor;
		themeName = "yellow";
		themesUi.gameObject.SetActive(false);
	}

	public void BlueTheme(){
		camera.backgroundColor = blueThemeColor;
		themeName = "blue";
		themesUi.gameObject.SetActive(false);
	}

	public void PinkTheme(){
		camera.backgroundColor = pinkThemeColor;
		themeName = "pink";
		themesUi.gameObject.SetActive(false);
	}
}
