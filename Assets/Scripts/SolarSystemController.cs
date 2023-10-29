using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static PlanetData;

public class SolarSystemController : MonoBehaviour
{
    private Vector3 scaleVenus;
    private Vector3 scaleMercury;
    private Vector3 scaleMars;
    private Vector3 scaleUranus;
    private Vector3 scaleSaturn;
    private Vector3 scaleJupiter;
    private Vector3 scaleNeptune;
    public bool realistic;
    // Start is called before the first frame update
    void Start()
    {
        realistic = false;
        PlanetManager.current.OnTimeChange += UpdatePosition;
        scaleVenus = PlanetManager.current.Venus.transform.localScale;
        scaleMercury = PlanetManager.current.Mercury.transform.localScale;
        scaleMars = PlanetManager.current.Mars.transform.localScale;
        scaleUranus = PlanetManager.current.Uranus.transform.localScale;
        scaleNeptune = PlanetManager.current.Neptune.transform.localScale;
        scaleJupiter = PlanetManager.current.Jupiter.transform.localScale;
        scaleSaturn = PlanetManager.current.Saturn.transform.localScale;
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

    public void realistic_activator(bool realistic) {
        if (realistic) { 
            PlanetManager.current.Venus.transform.localScale = new Vector3(25.62f, 25.62f, 25.62f);
            PlanetManager.current.Mars.transform.localScale = new Vector3(14.36f, 14.36f, 14.36f);
            PlanetManager.current.Uranus.transform.localScale = new Vector3(108.18f, 108.18f, 108.18f);
            PlanetManager.current.Saturn.transform.localScale = new Vector3(255.12f, 255.12f, 255.12f);
            PlanetManager.current.Jupiter.transform.localScale = new Vector3(303.43f, 303.43f, 303.43f);
            PlanetManager.current.Mercury.transform.localScale = new Vector3(10.35f, 10.35f, 10.35f);
            PlanetManager.current.Neptune.transform.localScale = new Vector3(104.91f, 104.91f, 104.91f);
        }
        else
        {
            PlanetManager.current.Venus.transform.localScale = scaleVenus;
            PlanetManager.current.Mars.transform.localScale = scaleMars;
            PlanetManager.current.Uranus.transform.localScale = scaleUranus;
            PlanetManager.current.Saturn.transform.localScale = scaleSaturn;
            PlanetManager.current.Jupiter.transform.localScale = scaleJupiter;
            PlanetManager.current.Mercury.transform.localScale = scaleMercury;
            PlanetManager.current.Neptune.transform.localScale = scaleNeptune;
        }
    }
 }
