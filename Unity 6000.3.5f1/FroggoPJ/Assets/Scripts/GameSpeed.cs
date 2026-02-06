using UnityEngine;

public class GameSpeed : MonoBehaviour
{
    public static GameSpeed Instance;

    public float startSpeed = 3f;
    public float speedIncreasePerSecond = 0.2f;
    public float maxSpeed = 12f;

    public float CurrentSpeed { get; private set; }

    void Awake()
    {
        Instance = this;
        CurrentSpeed = startSpeed;
    }

    void Update()
    {
        CurrentSpeed = Mathf.Min(maxSpeed, CurrentSpeed + speedIncreasePerSecond * Time.deltaTime);
    }
}