using UnityEngine;

public class LoopingGround : MonoBehaviour
{
    public float speed = 6f;
    public SpriteRenderer otherRenderer;
    public float overlap = 0.02f;

    SpriteRenderer sr;
    private Camera cam;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        cam = Camera.main;
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        float camLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;

        if (sr.bounds.max.x < camLeft)
        {
            float newX = otherRenderer.bounds.max.x + sr.bounds.extents.x - overlap;
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }
}