using UnityEngine;

public class LoopingGround : MonoBehaviour
{
    public float speed = 6f;
    public Transform otherTile;      
    public Camera cam;               

    SpriteRenderer sr;
    float width;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        width = sr.bounds.size.x;
        if (!cam) cam = Camera.main;
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        float camLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;

        if (sr.bounds.max.x < camLeft)
        {
            transform.position = new Vector3(
                otherTile.position.x + width,
                transform.position.y,
                transform.position.z
            );
        }
    }
}