using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetInfo : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject planetObject;
    public PlanetData.Planet PlanetName;
    public float size;
    public string info;
    public Text infoText;

    public PlanetInfo(GameObject gameObject, PlanetData.Planet planetName, float Period, float Size, string text)
    {
        planetObject = gameObject;
        PlanetName = planetName;
        size = Size;
        info = text;
    }
    void Start()
    {
        infoText = GameObject.Find("InfoText").GetComponent<Text>(); //this is what i did to get the infotext object
        infoText.enabled = false;
        
}

    void OnMouseEnter()
    {
        infoText.enabled = true;
        infoText.text = $"Planet: {PlanetName} \nSize: {size} km\nInfo: {info}";
    }

    void OnMouseExit()
    {
        infoText.enabled = false;
    }
}
