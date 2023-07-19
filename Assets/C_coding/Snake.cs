using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    public float jumpForce = 5f; // 
    public float gravityScale = 1f; // 
    public float horizontalSpeed = 3f; // 
    public float maxHeight = 5f; // 
    public float minHeight = -5f; // 
    public GameObject UI_start;

    private Rigidbody2D rb;
    private bool isDead = false;
    private bool isStarted = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // Начально устанавливаем гравитацию в 0, чтобы персонаж не падал
    }

    private void Update()
    {
        if (isDead)
            return;

        if (!isStarted)
        {
            // Проверяем, нажал ли игрок на левую кнопку мыши, чтобы начать уровень
            if (Input.GetMouseButtonDown(0))
            {
                isStarted = true;
                rb.gravityScale = gravityScale; // Включаем гравитацию после первого нажатия
                UI_start.SetActive(false);
            }
            return;
        }

        // Проверяем, тапнул ли игрок по экрану (производим прыжок)
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        // 
        if (transform.position.y <= minHeight || transform.position.y >= maxHeight)
        {
            Die();
        }

        // 
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, minHeight, maxHeight), transform.position.z);
    }

    private void FixedUpdate()
    {
        if (isDead || !isStarted)
            return;

        // 
        rb.velocity = new Vector2(horizontalSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        //
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void Die()
    {
        SceneManager.LoadScene(0);
    }
}
