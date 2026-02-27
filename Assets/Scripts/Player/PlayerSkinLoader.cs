using System.Collections.Generic; // Required to use Lists
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

        // 2. Validation check to make sure the index is valid
        if (savedIndex >= 0 && savedIndex < shipOptions.Length)
        {
            // 3. Get the components
            SpriteRenderer playerSprite = GetComponent<SpriteRenderer>();
            PolygonCollider2D polyCollider = GetComponent<PolygonCollider2D>();

            if (playerSprite != null)
            {
                // 4. Change the visual sprite
                playerSprite.sprite = shipOptions[savedIndex];

                // 5. Instantly update the hitbox to match the new sprite
                if (polyCollider != null)
                {
                    UpdateHitbox(playerSprite.sprite, polyCollider);
                }
            }
        }
    }

    /// <summary>
    /// Redraws the PolygonCollider2D to perfectly wrap around the new sprite
    /// </summary>
    private void UpdateHitbox(Sprite newSprite, PolygonCollider2D collider)
    {
        // Get the number of paths (outlines) in the new sprite's physics shape
        int shapeCount = newSprite.GetPhysicsShapeCount();
        collider.pathCount = shapeCount;

        // Create a list to hold the points of the outline
        List<Vector2> path = new List<Vector2>();

        // Loop through the shape, get the points, and apply them to the collider
        for (int i = 0; i < shapeCount; i++)
        {
            newSprite.GetPhysicsShape(i, path);
            collider.SetPath(i, path.ToArray());
        }
    }
}