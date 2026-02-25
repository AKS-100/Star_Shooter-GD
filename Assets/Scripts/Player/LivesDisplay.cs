using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required to manipulate Image components

/// <summary>
/// This class inherits from the UIelement class and handles updating the player's lives display
/// </summary>
public class LivesDisplay : UIelement
{
    [Tooltip("The Health script of the player")]
    public Health playerHealth;

    [Tooltip("List of UI Images that represent the player's lives")]
    public List<Image> lifeIcons;

    /// <summary>
    /// Description:
    /// Updates the lives display by turning icons on or off
    /// </summary>
    public void DisplayLives()
    {
        if (playerHealth != null)
        {
            for (int i = 0; i < lifeIcons.Count; i++)
            {
                // If the icon's index is less than current lives, turn the image on. 
                // Otherwise, turn it off.
                if (i < playerHealth.currentLives)
                {
                    lifeIcons[i].enabled = true;
                }
                else
                {
                    lifeIcons[i].enabled = false;
                }
            }
        }
    }

    /// <summary>
    /// Description:
    /// Overrides the virtual UpdateUI function from UIelement
    /// </summary>
    public override void UpdateUI()
    {
        base.UpdateUI();
        DisplayLives();
    }
}