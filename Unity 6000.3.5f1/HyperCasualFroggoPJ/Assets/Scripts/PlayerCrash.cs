using UnityEngine;

public class PlayerCrash : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameManager.I.GameOver();
            Debug.Log("Game Over");
        }
    }
}
