      using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;

    public float Gravity = 9.81f * 2f;
    public float JumpForce = 8f;

    void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    void OnEnable()
    {
        direction = Vector3.zero;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    void Update()
    {
        direction += Vector3.down * Gravity * Time.deltaTime;

        if (character.isGrounded)
        {
            direction = Vector3.down;

            if(Input.GetButton("Jump"))
            {
                direction = Vector3.up * JumpForce;
            }
        }

        character.Move(direction*Time.deltaTime);
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0f;
    }
}
