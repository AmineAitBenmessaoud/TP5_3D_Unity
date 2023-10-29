using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VitesseController : MonoBehaviour
{
    public TMP_InputField dateInputField;

    void Start()
    {
        // Inscrivez la fonction HandleDateInput aux �v�nements de modification de la zone de texte
        dateInputField.onValueChanged.AddListener(HandleDateInput);
    }

    public void HandleDateInput(string text)
    {
        // Convertissez le texte de la zone de texte en vitesse (double)
        double vitesse;
        if (double.TryParse(text, out vitesse))
        {
            // Mettez � jour la date dans votre mod�le (PlanetManager)
            PlanetManager.current.set_vitesse(vitesse);
        }
        else
        {
            Debug.LogError("Bad format of vitesse");
        }
    }
}
