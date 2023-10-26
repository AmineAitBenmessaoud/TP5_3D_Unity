using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
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

    private void Awake(){     
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
        Date = date.dateTime.AddDays(0.1);
}
} 
