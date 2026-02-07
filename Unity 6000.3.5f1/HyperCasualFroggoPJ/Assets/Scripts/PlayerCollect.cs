using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public int flyValue = 1;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            ScoreManager.I.Add(flyValue);
            Destroy(other.gameObject);
        }
    }
}
