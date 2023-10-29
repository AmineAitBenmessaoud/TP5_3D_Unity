using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class PlanetManager : MonoBehaviour {     
    public static PlanetManager current;
    public GameObject Mercury;
    public GameObject Venus;
    public GameObject Earth;
    public GameObject Mars;
    public GameObject Jupiter;
    public GameObject Saturn;
    public GameObject Uranus;
    public GameObject Neptune;
    private bool dynamic;
    private double vitesse;

    private void Awake(){
        dynamic = false;
        vitesse = 0.1;
        if (current == null){            
            current = this;         
        }        
        else{             
            Destroy(obj: this);        
        }     
        date = DateTime.Now;
    }
    public event Action<DateTime> OnTimeChange; 
    public void TimeChanged(DateTime newTime) { 
        OnTimeChange?.Invoke(newTime); 
    }
    private UDateTime date; 
    public UDateTime Date
    {
        get => date;
        set
        {
            date = value;
            TimeChanged(value.dateTime); //Fire the event
        }     
    }
    private void Update()
    {
         if (dynamic==true)
        {
           Date = date.dateTime.AddDays(vitesse);
        }
    }
    public void set_dynamic(bool activate_dynamic) {
        dynamic = activate_dynamic;
    }
    public void set_vitesse(double vitesse)
    {
        this.vitesse = vitesse;
    }
} 
