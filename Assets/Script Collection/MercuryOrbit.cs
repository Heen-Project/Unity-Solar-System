using UnityEngine;
using System.Collections;

public class MercuryOrbit : MonoBehaviour {
	Transform thisPlanet;
	public Transform parentPlanet;
	private Transform centerRotation;
	// Use this for initialization
	void Start () {
		thisPlanet = transform;
		centerRotation = new GameObject ("Mercury Rotation").transform;
		centerRotation.position = parentPlanet.position;
		thisPlanet.parent = centerRotation;
		thisPlanet.localPosition = new Vector3(0, 0, SolarSystem.MercuryDistance);
	}
	
	// Update is called once per frame
	void Update () {
		if (SolarSystem.rotateCondition)
        {
            centerRotation.Rotate(0, (360 / SolarSystem.MercuryYear) * Time.deltaTime * SolarSystem.OrbitSpeed, 0);
            thisPlanet.Rotate(0, (360 / SolarSystem.MercuryDay) * Time.deltaTime * SolarSystem.RotationSpeed, 0, Space.Self);
        }
	}
	void OnMouseDown () {
		Debug.Log("Mercury Clicked");
		SolarSystem.LightSelector = 1;
		SolarSystem.rotateCondition = false;
		SolarSystem.informationBoxCondition = true;
	}
}
