using UnityEngine;

public class PlayerSkinLoader : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Drag the SAME ship sprites here, in the SAME order as the menu")]
    public Sprite[] shipOptions;

    private void Start()
    {
        // 1. Get the saved index
        int savedIndex = PlayerPrefs.GetInt("SelectedShip", 0);

        // 2. validation check to make sure the index is valid
        if (savedIndex >= 0 && savedIndex < shipOptions.Length)
        {
            // 3. Get the player's SpriteRenderer and change the sprite
            SpriteRenderer playerSprite = GetComponent<SpriteRenderer>();
            if (playerSprite != null)
            {
                playerSprite.sprite = shipOptions[savedIndex];
            }
        }
    }
}