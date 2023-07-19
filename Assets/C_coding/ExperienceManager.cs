using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour
{
    public Text experienceText; // Ссылка на текстовое поле, отображающее опыт
    private int experience = 0; // Начальное значение опыта

    private void Start()
    {
        InvokeRepeating("AddExperience", 10f, 10f); // Запускаем метод AddExperience каждые 10 секунд
        UpdateExperienceText(); // Обновляем текстовое поле с начальным значением опыта
    }

    private void AddExperience()
    {
        experience += 100; // Увеличиваем опыт на 100
        UpdateExperienceText(); // Обновляем текстовое поле после увеличения опыта
    }

    private void UpdateExperienceText()
    {
        experienceText.text = "Опыт: " + experience.ToString(); // Обновляем текстовое поле с текущим значением опыта
    }
}
