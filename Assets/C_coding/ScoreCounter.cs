using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text scoreText; // ������ �� ��������� ����, ������������ ����
    private int score = 0; // ��������� �������� ��������

    private void Start()
    {
        UpdateScoreText(); // ��������� ��������� ���� � ��������� ��������� ��������
    }

    public void IncreaseScore(int amount)
    {
        score += amount; // ����������� ���� �� �������� ��������
        UpdateScoreText(); // ��������� ��������� ���� ����� ���������� ��������
    }

    private void UpdateScoreText()
    {
        scoreText.text = "�����: " + score.ToString(); // ��������� ��������� ���� � ������� ��������� ��������
    }
}
