using UnityEngine;
using UnityEngine.SceneManagement;

public class DieOnCloseToPlayer : MonoBehaviour
{
    public string playerTag = "Player"; // ��� ������
    public float maxDistance = 1f; // ������������ ���������� ��� ������������ ������

    private GameObject player; // ������ �� ������

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag); // ������� ������ �� ����
    }

    private void Update()
    {
        // ��������� ���������� ����� �������� � �������
        if (player != null && Vector2.Distance(transform.position, player.transform.position) <= maxDistance)
        {
            Die(); // �������� ����� ������
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(0);
    }
}
