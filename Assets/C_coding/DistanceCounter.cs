using UnityEngine;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour
{
    public Text distanceText; // ������ �� ��������� ����, ������������ ���������� ����������
    private Transform playerTransform; // ������ �� ��������� ������
    private Vector3 lastPosition; // ��������� ������� ������

    private float totalDistance = 0f; // ����� ���������� ����������

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // ������� ������ �� ����
        lastPosition = playerTransform.position; // ��������� ����������� ������� ������
        UpdateDistanceText(); // ��������� ��������� ���� � ��������� ��������� ����������
    }

    private void Update()
    {
        // ��������� ���������� ���������� ��� ������� ����� ������� �������� � ��������� �������� ������
        float distanceDelta = playerTransform.position.x - lastPosition.x;
        totalDistance += Mathf.Abs(distanceDelta); // ���������� ���������� �������� ������� (����� ������������ �������� �����)

        // ��������� ��������� ������� ������
        lastPosition = playerTransform.position;

        // ��������� ��������� ���� � ���������� �����������
        UpdateDistanceText();
    }

    private void UpdateDistanceText()
    {
        distanceText.text = "����������: " + totalDistance.ToString("F1") + " m"; // ��������� ��������� ���� � ������� ��������� ����������� ����������
    }
}
