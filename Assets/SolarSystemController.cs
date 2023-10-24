using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemController : MonoBehaviour
{
    private PlanetManager planetManager;  

    // Start is called before the first frame update
    void Start()
    {
        PlanetManager.current.OnTimeChange += UpdatePosition;
        planetManager = PlanetManager.current;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition(planetManager.Date);
    }
    public void UpdatePosition(DateTime t) {
        planetManager.Earth.transform.position=PlanetData.GetPlanetPosition(PlanetData.Planet.Earth, t);
    }
}
