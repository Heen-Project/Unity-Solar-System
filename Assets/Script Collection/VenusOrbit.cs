using UnityEngine;
using System.Collections;

public class VenusOrbit : MonoBehaviour {
	Transform thisPlanet;
	public Transform parentPlanet;
	private Transform centerRotation;
	// Use this for initialization
	void Start () {
		thisPlanet = transform;
		centerRotation = new GameObject ("Venus Rotation").transform;
		centerRotation.position = parentPlanet.position;
		thisPlanet.parent = centerRotation;
		thisPlanet.localPosition = new Vector3(0, 0, SolarSystem.VenusDistance);
	}
	
	// Update is called once per frame
	void Update () {
		if (SolarSystem.rotateCondition)
        {
            centerRotation.Rotate(0, (360 / SolarSystem.VenusYear) * Time.deltaTime * SolarSystem.OrbitSpeed, 0);
            thisPlanet.Rotate(0, (360 / SolarSystem.VenusDay) * Time.deltaTime * SolarSystem.RotationSpeed, 0, Space.Self);
        }
	}
	void OnMouseDown () {
		Debug.Log("Venus Clicked");
		SolarSystem.LightSelector = 2;
		SolarSystem.rotateCondition = false;
		SolarSystem.informationBoxCondition = true;
	}
}
