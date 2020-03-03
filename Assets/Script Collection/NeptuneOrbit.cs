using UnityEngine;
using System.Collections;

public class NeptuneOrbit : MonoBehaviour {
	Transform thisPlanet;
	public Transform parentPlanet;
	private Transform centerRotation;
	// Use this for initialization
	void Start () {
		thisPlanet = transform;
		centerRotation = new GameObject ("Neptune Rotation").transform;
		centerRotation.position = parentPlanet.position;
		thisPlanet.parent = centerRotation;
		thisPlanet.localPosition = new Vector3(0, 0, SolarSystem.NeptuneDistance);
	}
	
	// Update is called once per frame
	void Update () {
		if (SolarSystem.rotateCondition)
        {
            centerRotation.Rotate(0, (360 / SolarSystem.NeptuneYear) * Time.deltaTime * SolarSystem.OrbitSpeed, 0);
            thisPlanet.Rotate(0, (360 / SolarSystem.NeptuneDay) * Time.deltaTime * SolarSystem.RotationSpeed, 0, Space.Self);
        }
	}

	void OnMouseDown () {
		Debug.Log("Neptune Clicked");
		SolarSystem.LightSelector = 8;
		SolarSystem.rotateCondition = false;
		SolarSystem.informationBoxCondition = true;
	}
}
