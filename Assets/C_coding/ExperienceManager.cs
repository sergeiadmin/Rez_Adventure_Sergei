using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour
{
    public Text experienceText; // ������ �� ��������� ����, ������������ ����
    private int experience = 0; // ��������� �������� �����

    private void Start()
    {
        InvokeRepeating("AddExperience", 10f, 10f); // ��������� ����� AddExperience ������ 10 ������
        UpdateExperienceText(); // ��������� ��������� ���� � ��������� ��������� �����
    }

    private void AddExperience()
    {
        experience += 100; // ����������� ���� �� 100
        UpdateExperienceText(); // ��������� ��������� ���� ����� ���������� �����
    }

    private void UpdateExperienceText()
    {
        experienceText.text = "����: " + experience.ToString(); // ��������� ��������� ���� � ������� ��������� �����
    }
}
