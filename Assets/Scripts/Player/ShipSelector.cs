using UnityEngine;
using UnityEngine.UI; 

public class ShipSelector : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Drag all your ship sprites here (Order matters!)")]
    public Sprite[] shipOptions;

    [Tooltip("The UI Image that shows the currently selected ship")]
    public Image displayImage;

    // Internal variable to track which ship is selected
    private int currentShipIndex = 0;

    private void Start()
    {
        currentShipIndex = PlayerPrefs.GetInt("SelectedShip", 0);
        UpdateDisplay();
    }

    public void NextShip()
    {
        currentShipIndex++;
        if (currentShipIndex >= shipOptions.Length)
        {
            currentShipIndex = 0; 
        }
        UpdateDisplay();
        SaveSelection();
    }

    public void PreviousShip()
    {
        currentShipIndex--;
        if (currentShipIndex < 0)
        {
            currentShipIndex = shipOptions.Length - 1; 
        }
        UpdateDisplay();
        SaveSelection();
    }

    private void UpdateDisplay()
    {
        if (displayImage != null && shipOptions.Length > 0)
        {
            displayImage.sprite = shipOptions[currentShipIndex];
            displayImage.preserveAspect = true; 
        }
    }

    private void SaveSelection()
    {
        PlayerPrefs.SetInt("SelectedShip", currentShipIndex);
        PlayerPrefs.Save();
    }
}