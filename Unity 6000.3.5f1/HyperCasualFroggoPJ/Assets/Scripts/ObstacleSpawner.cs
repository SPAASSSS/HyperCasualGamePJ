using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject logPrefab;
    public float minDelay = 1.0f;
    public float maxDelay = 2.2f;

    public float spawnOffsetX = 2.0f;
    public float groundY = -3.7f;
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
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            float camRight = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
            Vector3 pos = new Vector3(camRight + spawnOffsetX, groundY, 0f);

            var obj = Instantiate(logPrefab, pos, Quaternion.identity);

            var mover = obj.GetComponent<ObstacleMove>();
            if (mover) mover.speed = scrollSpeed;
        }
    }
}