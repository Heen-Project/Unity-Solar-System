using UnityEngine;
using System.Collections;

public class SunOrbit : MonoBehaviour {
	Transform thisPlanet;
	// Use this for initialization
	void Start () {
		thisPlanet = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (SolarSystem.rotateCondition)
		{
			thisPlanet.Rotate(0, (360 / 28*24) * Time.deltaTime * SolarSystem.RotationSpeed, 0, Space.Self);
		}
	}
	void OnMouseDown () {
		Debug.Log("Sun Clicked");
		SolarSystem.LightSelector = 0;
		SolarSystem.rotateCondition = false;
		SolarSystem.informationBoxCondition = true;
	}
}
