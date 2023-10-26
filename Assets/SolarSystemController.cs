using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlanetData;

public class SolarSystemController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        PlanetManager.current.OnTimeChange += UpdatePosition;
    }


    // Update is called once per frame
    public void UpdatePosition(DateTime t) {
        PlanetManager.current.Earth.transform.position= PlanetData.GetPlanetPosition(Planet.Earth,t);
        PlanetManager.current.Venus.transform.position = PlanetData.GetPlanetPosition(Planet.Venus, t);
        PlanetManager.current.Mars.transform.position = PlanetData.GetPlanetPosition(Planet.Mars, t);
        PlanetManager.current.Uranus.transform.position = PlanetData.GetPlanetPosition(Planet.Uranus, t);
        PlanetManager.current.Saturn.transform.position = PlanetData.GetPlanetPosition(Planet.Saturn, t);
        PlanetManager.current.Jupiter.transform.position = PlanetData.GetPlanetPosition(Planet.Jupiter, t);
        PlanetManager.current.Mercury.transform.position = PlanetData.GetPlanetPosition(Planet.Mercury, t);
        PlanetManager.current.Neptune.transform.position = PlanetData.GetPlanetPosition(Planet.Neptune, t);
    }
}
