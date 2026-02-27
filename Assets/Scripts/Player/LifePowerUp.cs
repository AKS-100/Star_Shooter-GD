using UnityEngine;

public class LifePowerUp : MonoBehaviour
{
    public int livesToAdd = 1;
    public GameObject collectEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Health playerHealth = collision.GetComponent<Health>();
            
            if (playerHealth != null)
            {
                if (playerHealth.currentLives < playerHealth.maximumLives)
                {
                    playerHealth.currentLives += livesToAdd;
                    GameManager.UpdateUIElements();
                    
                    if (collectEffect != null)
                    {
                        Instantiate(collectEffect, transform.position, transform.rotation);
                    }
                    
                    Destroy(gameObject);
                }
            }
        }
    }
}