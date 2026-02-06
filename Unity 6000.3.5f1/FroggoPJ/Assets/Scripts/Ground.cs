using UnityEngine;

public class Ground : MonoBehaviour
{
    private float width;

    void Start()
    {
        width = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        transform.position += Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime;

        // ถ้าพื้นหลุดซ้ายจอ
        if (transform.position.x <= -width)
        {
            Reposition();
        }
    }

    void Reposition()
    {
        // หาพื้นที่อยู่ขวาสุด
        float rightMostX = GetRightMostGroundX();

        transform.position = new Vector3(
            rightMostX + width,
            transform.position.y,
            transform.position.z
        );
    }

    float GetRightMostGroundX()
    {
        Ground[] grounds = FindObjectsOfType<Ground>();
        float maxX = grounds[0].transform.position.x;

        foreach (Ground g in grounds)
        {
            if (g.transform.position.x > maxX)
                maxX = g.transform.position.x;
        }

        return maxX;
    }
}