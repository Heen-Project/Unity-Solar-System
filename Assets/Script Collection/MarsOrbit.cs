using UnityEngine;
using System.Collections;

public class MarsOrbit : MonoBehaviour {
	Transform thisPlanet;
	public Transform parentPlanet;
	private Transform centerRotation;
	// Use this for initialization
	void Start () {
		thisPlanet = transform;
		centerRotation = new GameObject ("Mars Rotation").transform;
		centerRotation.position = parentPlanet.position;
		thisPlanet.parent = centerRotation;
		thisPlanet.localPosition = new Vector3(0, 0, SolarSystem.MarsDistance);
	}
	
	// Update is called once per frame
	void Update () {
		if (SolarSystem.rotateCondition)
        {
            centerRotation.Rotate(0, (360 / SolarSystem.MarsYear) * Time.deltaTime * SolarSystem.OrbitSpeed, 0);
            thisPlanet.Rotate(0, (360 / SolarSystem.MarsDay) * Time.deltaTime * SolarSystem.RotationSpeed, 0, Space.Self);
        }
	}
	void OnMouseDown () {
		Debug.Log("Mars Clicked");
		SolarSystem.LightSelector = 4;
		SolarSystem.rotateCondition = false;
		SolarSystem.informationBoxCondition = true;
	}
}
