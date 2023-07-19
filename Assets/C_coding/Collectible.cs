using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string playerTag = "Player"; // ��� ������
    public int scoreValue = 1; // ��������, �� ������� ���������� ����
    public float magnetSpeed = 2f; // �������� ���������� � ������

    private GameObject player; // ������ �� ������
    private Vector3 initialPosition; // ����������� ������� �������

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag); // ������� ������ �� ����
        initialPosition = transform.position; // ��������� ����������� ������� �������
    }

    private void Update()
    {
        // ��������� ���������� ����� �������� � �������
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (player != null && distanceToPlayer <= 4f)
        {
            MagnetToPlayer(); // ����������� ������ � ������
        }
        if (player != null && distanceToPlayer <= 0.8f)
        {
            Collect(); // �������� ����� ����� 
        }
    }

    private void MagnetToPlayer()
    {
        // ������������� ������� ������� � ������� ������ � �������������� �������� ������������ (Lerp)
        float step = magnetSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, player.transform.position, step);
    }

    private void Collect()
    {
        ScoreCounter scoreCounter = FindObjectOfType<ScoreCounter>(); // ������� ������ ����� � ����������� ScoreCounter
        if (scoreCounter != null)
        {
            scoreCounter.IncreaseScore(scoreValue); // ����������� ���� �� �������� ��������
        }
        Destroy(gameObject); // ���������� ������ ����� �����
    }
}
