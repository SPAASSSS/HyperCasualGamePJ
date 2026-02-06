using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float speed = 6f;
    Camera cam;
    SpriteRenderer sr;

    void Start()
    {
        cam = Camera.main;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        float camLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;

        if (sr != null && sr.bounds.max.x < camLeft - 1f)
            Destroy(gameObject);
    }
}
