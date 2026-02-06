using UnityEngine;

public class PlayerCrash : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Time.timeScale = 0f;
            Debug.Log("Game Over");
        }
    }
}
