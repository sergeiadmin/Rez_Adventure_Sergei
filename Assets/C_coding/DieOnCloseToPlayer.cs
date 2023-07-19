using UnityEngine;
using UnityEngine.SceneManagement;

public class DieOnCloseToPlayer : MonoBehaviour
{
    public string playerTag = "Player"; // Тег игрока
    public float maxDistance = 1f; // Максимальное расстояние для срабатывания смерти

    private GameObject player; // Ссылка на игрока

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag); // Находим игрока по тегу
    }

    private void Update()
    {
        // Проверяем расстояние между объектом и игроком
        if (player != null && Vector2.Distance(transform.position, player.transform.position) <= maxDistance)
        {
            Die(); // Вызываем метод смерти
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(0);
    }
}
