using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string playerTag = "Player"; // Тег игрока
    public int scoreValue = 1; // Значение, на которое увеличится счет
    public float magnetSpeed = 2f; // Скорость притяжения к игроку

    private GameObject player; // Ссылка на игрока
    private Vector3 initialPosition; // Изначальная позиция обьекта

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag); // Находим игрока по тегу
        initialPosition = transform.position; // Сохраняем изначальную позицию обьекта
    }

    private void Update()
    {
        // Проверяем расстояние между объектом и игроком
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (player != null && distanceToPlayer <= 4f)
        {
            MagnetToPlayer(); // Притягиваем объект к игроку
        }
        if (player != null && distanceToPlayer <= 0.8f)
        {
            Collect(); // Вызываем метод сбора 
        }
    }

    private void MagnetToPlayer()
    {
        // Интерполируем позицию обьекта к позиции игрока с использованием линейной интерполяции (Lerp)
        float step = magnetSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, player.transform.position, step);
    }

    private void Collect()
    {
        ScoreCounter scoreCounter = FindObjectOfType<ScoreCounter>(); // Находим объект сцены с компонентом ScoreCounter
        if (scoreCounter != null)
        {
            scoreCounter.IncreaseScore(scoreValue); // Увеличиваем счет на заданное значение
        }
        Destroy(gameObject); // Уничтожаем объект после сбора
    }
}
