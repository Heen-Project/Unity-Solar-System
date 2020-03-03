using UnityEngine;
using System.Collections;

public class MoonOrbit : MonoBehaviour {
	Transform thisPlanet;
	public Transform parentPlanet;
	private Transform centerRotation;
	float moonDistance = 3.0f, moonOrbitSpeed = 10.0f , moonRotationSpeed = 1.0f;

	// Use this for initialization
	void Start () {
		thisPlanet = transform;
		centerRotation = new GameObject ("Moon Rotation").transform;
		centerRotation.position = parentPlanet.position;
		thisPlanet.parent = centerRotation;
		thisPlanet.localPosition = new Vector3(0, 0, moonDistance);

	}
	
	// Update is called once per frame
	void Update () {
		if (SolarSystem.rotateCondition)
		{
			centerRotation.position = parentPlanet.position;
			thisPlanet.parent = centerRotation;
			/*centerRotation.Rotate(0, (float)((360 / 27.322) * Time.deltaTime * moonOrbitSpeed),0);
			thisPlanet.Rotate(0, (float) (360 / 27.322) * Time.deltaTime * moonRotationSpeed, 0, Space.Self);*/
			centerRotation.Rotate(0, (float)(360 / 27.322) * Time.deltaTime * SolarSystem.OrbitSpeed, 0);
			thisPlanet.Rotate(0, (float)(360 / 27.322) * Time.deltaTime * SolarSystem.RotationSpeed, 0, Space.Self);
		}
	}
}
