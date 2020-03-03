﻿using UnityEngine;
using System.Collections;

public class EarthOrbit : MonoBehaviour {
	Transform thisPlanet;
	public Transform parentPlanet;
	private Transform centerRotation;
	// Use this for initialization
	void Start () {
		thisPlanet = transform;
		centerRotation = new GameObject ("Earth Rotation").transform;
		centerRotation.position = parentPlanet.position;
		thisPlanet.parent = centerRotation;
		thisPlanet.localPosition = new Vector3(0, 0, SolarSystem.EarthDistance);
	}
	
	// Update is called once per frame
	void Update () {
		if (SolarSystem.rotateCondition)
        {
            centerRotation.Rotate(0, (360 / SolarSystem.EarthYear) * Time.deltaTime * SolarSystem.OrbitSpeed, 0);
            thisPlanet.Rotate(0, (360 / SolarSystem.EarthDay) * Time.deltaTime * SolarSystem.RotationSpeed, 0, Space.Self);
        }
	}
	void OnMouseDown () {
		Debug.Log("Earth Clicked");
		SolarSystem.LightSelector = 3;
		SolarSystem.rotateCondition = false;
		SolarSystem.informationBoxCondition = true;
	}
}