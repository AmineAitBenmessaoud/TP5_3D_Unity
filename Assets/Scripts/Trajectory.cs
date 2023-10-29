using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public int numberOfPlanets; // Nombre de planètes
    public DateTime currentTime; // Temps de départ
    public Boolean showAllTrajectories;
    public PlanetManager planetManager;

    private List<LineRenderer> lineRenderers = new List<LineRenderer>();

    void Start()
    {
        showAllTrajectories = true;

        ToggleTrajectories();
        
    }
    private void Update()
    {
        if (showAllTrajectories)
        {
            CreateTrajectoryLines();
        }
    }

    public void CreateTrajectoryLines()
    {
        numberOfPlanets = 7;

        for (int i = 0; i < numberOfPlanets; i++)
        {
            GameObject lineObject = new GameObject("TrajectoryLine_" + i);
            LineRenderer lineRenderer = lineObject.AddComponent<LineRenderer>();
            lineRenderers.Add(lineRenderer);
            DrawTrajectory(planetManager.planets[i], lineRenderer);
        }
    }

    public void DrawTrajectory(PlanetInfo planet, LineRenderer lineRenderer)
    {
        List<Vector3> trajectoryPoints = CalculateTrajectory(planet);
        lineRenderer.positionCount = trajectoryPoints.Count;
        lineRenderer.SetPositions(trajectoryPoints.ToArray());
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
    }

    public List<Vector3> CalculateTrajectory(PlanetInfo planet)
    {
        List<Vector3> points = new List<Vector3>();
        //float totalDays = planet.period;
        int maxDays = 400;
        float timeInterval = 1;
        DateTime targetTime = PlanetManager.current.Date;

        for (int i = 0; i <= maxDays; i++)
        {
            Vector3 planetPosition = PlanetData.GetPlanetPosition(planet.PlanetName, targetTime);
            points.Add(planetPosition);
            targetTime = targetTime.AddDays(timeInterval);
        }

        return points;
    }

    public void ToggleTrajectories()
    {
        foreach (LineRenderer lineRenderer in lineRenderers)
        {
            lineRenderer.enabled = showAllTrajectories;
        }
    }
    public void showTrajectories(bool trajectories_activator)
    {
        showAllTrajectories= trajectories_activator;
    }
}
