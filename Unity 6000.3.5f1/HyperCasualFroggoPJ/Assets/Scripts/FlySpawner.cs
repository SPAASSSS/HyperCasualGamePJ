using System.Collections;
using UnityEngine;

public class FlySpawner : MonoBehaviour
{
    public GameObject flyPrefab;

    public float minDelay = 0.6f;
    public float maxDelay = 1.4f;

    public float spawnOffsetX = 2f;
    public float minY = -2.2f;
    public float maxY = -0.6f;

    public float scrollSpeed = 6f;

    Camera cam;

    void Start()
    {
        cam = Camera.main;
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

            float camRight = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
            float y = Random.Range(minY, maxY);

            var obj = Instantiate(flyPrefab,
                new Vector3(camRight + spawnOffsetX, y, 0f),
                Quaternion.identity);

            var mover = obj.GetComponent<FlyMove>();
            if (mover) mover.speed = scrollSpeed;
        }
    }
}
