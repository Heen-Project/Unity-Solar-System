using UnityEngine;
using System.Collections;

public class SolarSystem : MonoBehaviour {
	public Texture2D sun2D, mercury2D, venus2D, earth2D, mars2D, jupiter2D, saturn2D, uranus2D, neptune2D;
    public static float OrbitSpeed = 100.0f;
	public static float RotationSpeed = 10.0f;
	public static int MercuryDistance = 150;
	public static float MercuryYear = 58.65f;
	public static float MercuryDay = 58.65f;
	public static int VenusDistance = 160;
	public static float VenusYear = 224.7f;
	public static float VenusDay = 243.0f;
	public static int EarthDistance = 165;
	public static float EarthYear = 365.26f;
	public static float EarthDay = 1.0f;
	public static int MarsDistance = 180;
	public static float MarsYear = 687.0f;
	public static float MarsDay = 1.03f;
	public static int JupiterDistance = 270;
	public static float JupiterYear = 11.86f*365.26f;
	public static float JupiterDay = 9.8f/24.0f;
	public static int SaturnDistance = 380;
	public static float SaturnYear = 29.46f*365.26f;
	public static float SaturnDay = 10.2f/24.0f;
	public static int UranusDistance = 630;
	public static float UranusYear = 84.07f*365.26f;
	public static float UranusDay = 17.9f/24.0f;
	public static int NeptuneDistance = 930;
	public static float NeptuneYear = 164.8f*365.26f;
	public static float NeptuneDay = 19.1f/24.0f;

	GameObject sunGO, mercuryGO, venusGO, earthGO, marsGO, jupiterGO, saturnGO, uranusGO, neptuneGO, mainCameraCustom;
	Light sunLH, mercuryLH, venusLH, earthLH, marsLH, jupiterLH, saturnLH, uranusLH, neptuneLH;

    MercuryOrbit mercuryCS;
    VenusOrbit venusCS;
    EarthOrbit earthCS;
    MarsOrbit marsCS;
    JupiterOrit jupiterCS;
    SaturnOrbit saturnCS;
    UranusOrbit uranusCS;
    NeptuneOrbit neptuneCS;

	int iconLeftPosition = 40;
	int iconTopPosition = 0;
	int iconWidthSize = 40;
	int iconHeightSize = 40;
	
	public static int LightSelector=0, LightHover;

	public static bool rotateCondition = true, informationBoxCondition = false;
	private static string namaPlanet, hoverPlanet, descriptionPlanet;

	void OnGUI (){
		GUI.DrawTexture (new Rect (iconLeftPosition * 0, iconTopPosition, iconWidthSize, iconHeightSize), sun2D);
		GUI.DrawTexture (new Rect (iconLeftPosition * 1, iconTopPosition, iconWidthSize, iconHeightSize), mercury2D);
		GUI.DrawTexture (new Rect (iconLeftPosition * 2, iconTopPosition, iconWidthSize, iconHeightSize), venus2D);
		GUI.DrawTexture (new Rect (iconLeftPosition * 3, iconTopPosition, iconWidthSize, iconHeightSize), earth2D);
		GUI.DrawTexture (new Rect (iconLeftPosition * 4, iconTopPosition, iconWidthSize, iconHeightSize), mars2D);
		GUI.DrawTexture (new Rect (iconLeftPosition * 5, iconTopPosition, iconWidthSize, iconHeightSize), jupiter2D);
		GUI.DrawTexture (new Rect (iconLeftPosition * 6, iconTopPosition, iconWidthSize, iconHeightSize), saturn2D);
		GUI.DrawTexture (new Rect (iconLeftPosition * 7, iconTopPosition, iconWidthSize, iconHeightSize), uranus2D);
		GUI.DrawTexture (new Rect (iconLeftPosition * 8, iconTopPosition, iconWidthSize, iconHeightSize), neptune2D);
		for (int i=0; i<9; i++) {
			if (i==LightSelector)continue;
			GUI.Box (new Rect (iconLeftPosition * i, iconTopPosition, iconWidthSize, iconHeightSize), "");
		}

		if (informationBoxCondition) {
			switch (LightSelector){
			case 0: namaPlanet = "Sun"; descriptionPlanet= "The Sun is the star at the center of the Solar System. It is by far the most important source of energy for life on Earth. The Sun is a nearly perfect spherical ball of hot plasma, with internal convective motion that generates a magnetic field via a dynamo process. Chemically, about three quarters of the Sun's mass consists of hydrogen, whereas the rest is mostly helium, and much smaller quantities of heavier elements, including oxygen, carbon, neon and iron.";break;
			case 1: namaPlanet="Mercury"; descriptionPlanet="Mercury is the planet closest to the Sun in our Solar System. This small, rocky planet has almost no atmosphere. Mercury has a very elliptical orbit and a huge range in temperature. During the long daytime (which lasts 58.65 Earth days or almost an entire Mercurian year, which is 88 days long), the temperature is hotter than an oven; during the long night (the same length), the temperature is colder than a freezer. "; break;
			case 2: namaPlanet="Venus";descriptionPlanet="Venus is the second planet from the sun in our solar system. It is the hottest planet in our Solar System. This planet is covered with fast-moving sulphuric acid clouds which trap heat from the Sun. Its thick atmosphere is mostly carbon dioxide. Venus has an iron core but only a very weak magnetic field.";break;
			case 3: namaPlanet="Earth";descriptionPlanet="The Earth is the third planet from the Sun in our Solar System. It is the planet we evolved on and the only planet in our Solar System that is known to support life. ";break;
			case 4: namaPlanet="Mars";descriptionPlanet="Mars, the red planet, is the fourth planet from the sun and the most Earth-like planet in our solar system. It is about half the size of Earth and has a dry, rocky surface and a very thin atmosphere. ";break;
			case 5: namaPlanet="Jupiter";descriptionPlanet="Jupiter is the fifth and largest planet in our solar system. This gas giant has a thick atmosphere, 39 known moons, and a dark, barely-visible ring. Its most prominent features are bands across its latitudes and a great red spot (which is a storm). ";break;
			case 6: namaPlanet="Saturn";descriptionPlanet="Saturn is the sixth planet from the sun in our solar system. It is the second-largest planet in our solar system (Jupiter is the largest). It has beautiful rings that are made mostly of ice chunks (and some rock) that range in size from the size of a fingernail to the size of a car. Saturn is made mostly of hydrogen and helium gas. ";break;
			case 7: namaPlanet="Uranus";descriptionPlanet="Uranus is the seventh planet from the sun in our solar system. This huge, ice giant is covered with clouds and is encircled by a belt of 11 rings and 22 known moons. Uranus' blue color is caused by the methane (CH4) in its atmosphere; this molecule absorbs red light. ";break;
			case 8: namaPlanet="Neptune";descriptionPlanet="Neptune is the eighth planet from the sun in our solar system. This ice giant has a hazy atmosphere and strong winds. It is orbited by eight moons and narrow, faint rings arranged in clumps. Neptune's blue color is caused by the methane (CH4) in its atmosphere; this molecule absorbs red light.";break;
			}
			GUI.skin.box.wordWrap = true;
			GUI.skin.box.fontSize = 18;
			GUI.skin.box.alignment = TextAnchor.MiddleCenter;
			GUI.Box(new Rect(Screen.width-(Screen.width/8)*5,Screen.height/4-40, Screen.width/4,40), namaPlanet);
			//GUI.Box (new Rect(left top widh heigh
			GUI.Box(new Rect(Screen.width-(Screen.width/8)*5,Screen.height/4, Screen.width/4,Screen.height/2), descriptionPlanet);
			if(GUI.Button(new Rect((Screen.width - Screen.width/2)-20, (Screen.height/4)*3-10, 50, 20), "Close")){
				SolarSystem.LightSelector = 0;
				rotateCondition = true;
				informationBoxCondition = false;
			}
		}
		if (Input.mousePosition.x < Screen.width && Input.mousePosition.y < Screen.height)
		{
			if (((int)Input.mousePosition.x / 40) < 9 && ((int)(Screen.height - Input.mousePosition.y) / 40) < 1)
			{
				LightHover = (int)Input.mousePosition.x / 40;

				switch(LightHover){
					case 0: hoverPlanet = "Sun"; break;
					case 1: hoverPlanet="Mercury"; break;
					case 2: hoverPlanet="Venus";break;
					case 3: hoverPlanet="Earth";break;
					case 4: hoverPlanet="Mars";break;
					case 5: hoverPlanet="Jupiter";break;
					case 6: hoverPlanet="Saturn";break;
					case 7: hoverPlanet="Uranus";break;
					case 8: hoverPlanet="Neptune";break;
				}
					GUI.skin.box.wordWrap = true;
					GUI.skin.box.fontSize = 11;
					GUI.Box(
						new Rect(Input.mousePosition.x + 10, (Screen.height - Input.mousePosition.y), 50, 20),
					hoverPlanet);
					

				}
			}
		}




	// Use this for initialization
	void Start () {
		gameObjectFN ();
		lightNullCondition (false);

	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			//icon clicked
			if (((int)Input.mousePosition.x / 40) < 9 && ((int)(Screen.height - Input.mousePosition.y) / 40) < 1) {
				LightSelector = (int)Input.mousePosition.x / 40;
				Debug.Log("Icon "+LightSelector);
				lightFN(LightSelector);
			}
		}
//		lightFN(LightSelector);
	}

	void OnMouseDown(){

	}

	void lightFN(int LightSelected){
		lightNullCondition (false);
		//mainCameraCustom.GetComponent<Transform>().position = new Vector3 (0, 500, 0);
		//mainCameraCustom.GetComponent<Transform>().position = new Vector3 (0, 0, 150);
		//mainCameraCustom.rotation = new Vector3 (90, 270, 0);
		switch (LightSelected) {
		case 0: //sunLH.color = Color.blue;

			break;
		case 1:mercuryLH.enabled = true;

			//mainCameraCustom.GetComponent<Transform>().position = new Vector3 (0, 0, 151);
			//mainCameraCustom.GetComponent<Transform>().rotation = Quaternion.Slerp(transform.rotation, mercuryGO.GetComponent<Transform>().rotation,  Time.deltaTime * 2.0);
			//mainCameraCustom.GetComponent<Camera>().fieldOfView = 20;
			break;
		case 2:venusLH.enabled = true;

			break;
		case 3:earthLH.enabled = true;

			break;
		case 4:marsLH.enabled = true;

			break;
		case 5:jupiterLH.enabled = true;

			break;
		case 6:saturnLH.enabled = true;

			break;
		case 7:uranusLH.enabled = true;

			break;
		case 8:neptuneLH.enabled = true;

			break;
		}
	}

	void lightNullCondition( bool condition){
		Debug.Log (mercuryLH);
//		sunLH.color = Color (255, 183, 91, 255);
		mercuryLH.enabled = condition;
		venusLH.enabled = condition;
		earthLH.enabled = condition;
		marsLH.enabled = condition;
		jupiterLH.enabled = condition;
		saturnLH.enabled = condition;
		uranusLH.enabled = condition;
		neptuneLH.enabled = condition;
	}

	void gameObjectFN(){
		mercuryCS = GameObject.FindGameObjectWithTag("Mercury").GetComponent<MercuryOrbit>();
		venusCS = GameObject.FindGameObjectWithTag("Venus").GetComponent<VenusOrbit>();
		earthCS = GameObject.FindGameObjectWithTag("Earth").GetComponent<EarthOrbit>();
		marsCS = GameObject.FindGameObjectWithTag("Mars").GetComponent<MarsOrbit>();
		jupiterCS = GameObject.FindGameObjectWithTag("Jupiter").GetComponent<JupiterOrit>();
		saturnCS = GameObject.FindGameObjectWithTag("Saturn").GetComponent<SaturnOrbit>();
		uranusCS = GameObject.FindGameObjectWithTag("Uranus").GetComponent<UranusOrbit>();
		neptuneCS = GameObject.FindGameObjectWithTag("Neptune").GetComponent<NeptuneOrbit>();
		//Debug.Log ("CS "+mercuryCS);
		sunLH = GameObject.FindGameObjectWithTag ("Sun").GetComponent<Light> ();
		mercuryLH = GameObject.FindGameObjectWithTag("Mercury").GetComponent<Light>();
		venusLH = GameObject.FindGameObjectWithTag("Venus").GetComponent<Light>();
		earthLH = GameObject.FindGameObjectWithTag("Earth").GetComponent<Light>();
		marsLH = GameObject.FindGameObjectWithTag("Mars").GetComponent<Light>();
		jupiterLH = GameObject.FindGameObjectWithTag("Jupiter").GetComponent<Light>();
		saturnLH = GameObject.FindGameObjectWithTag("Saturn").GetComponent<Light>();
		uranusLH = GameObject.FindGameObjectWithTag("Uranus").GetComponent<Light>();
		neptuneLH = GameObject.FindGameObjectWithTag("Neptune").GetComponent<Light>();
		//Debug.Log ("LH "+mercuryLH);
		sunGO = GameObject.FindGameObjectWithTag ("Sun");
		mercuryGO = GameObject.FindGameObjectWithTag("Mercury");
		venusGO = GameObject.FindGameObjectWithTag("Venus");
		earthGO = GameObject.FindGameObjectWithTag("Earth");
		marsGO = GameObject.FindGameObjectWithTag("Mars");
		jupiterGO = GameObject.FindGameObjectWithTag("Jupiter");
		saturnGO = GameObject.FindGameObjectWithTag("Saturn");
		uranusGO = GameObject.FindGameObjectWithTag("Uranus");
		neptuneGO = GameObject.FindGameObjectWithTag("Neptune");
		//Debug.Log ("GO "+mercuryGO);
		mainCameraCustom = GameObject.FindGameObjectWithTag("MainCamera");
	}

}
