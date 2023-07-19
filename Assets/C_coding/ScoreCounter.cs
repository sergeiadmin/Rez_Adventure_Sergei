using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text scoreText; // Ссылка на текстовое поле, отображающее счет
    private int score = 0; // Начальное значение счетчика

    private void Start()
    {
        UpdateScoreText(); // Обновляем текстовое поле с начальным значением счетчика
    }

    public void IncreaseScore(int amount)
    {
        score += amount; // Увеличиваем счет на заданное значение
        UpdateScoreText(); // Обновляем текстовое поле после увеличения счетчика
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Бонус: " + score.ToString(); // Обновляем текстовое поле с текущим значением счетчика
    }
}
