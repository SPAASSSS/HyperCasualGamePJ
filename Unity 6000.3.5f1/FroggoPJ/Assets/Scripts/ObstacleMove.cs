using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float destroyX = -20f;

    void Update()
    {
        float spd = GameSpeed.Instance != null ? GameSpeed.Instance.CurrentSpeed : 3f;
        transform.position += Vector3.left * spd * Time.deltaTime;

        if (transform.position.x < destroyX)
            Destroy(gameObject);
    }
}