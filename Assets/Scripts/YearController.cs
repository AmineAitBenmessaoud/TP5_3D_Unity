using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class YearController : MonoBehaviour
{
    public TMP_InputField dateInputField;

    void Start()
    {
        // Inscrivez la fonction HandleDateInput aux événements de modification de la zone de texte
        dateInputField.onValueChanged.AddListener(HandleDateInput);
    }

    public void HandleDateInput(string text)
    {
        // Convertissez le texte de la zone de texte en date
        DateTime newDate;
        if (DateTime.TryParse(text, out newDate))
        {
            // Mettez à jour la date dans votre modèle (PlanetManager)
            PlanetManager.current.Date = newDate;
        }
        else
        {
            Debug.LogError("Format de date incorrect");
        }
    }
}
