using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Массив объектов для спавна
    public float spawnInterval = 2f; // Интервал между спавнами
    public float objectSpeed = 3f; // Скорость движения объектов
    public float despawnXPositionOffset = -40f; // Отступ для удаления объектов от положения игрока по оси X
    public float randomYSpawnRange = 5f; // Диапазон случайного спавна по высоте (ось Y)
    public GameObject player; // Ссылка на игрока

    private float lastSpawnTime; // Время последнего спавна

    private void Start()
    {
        lastSpawnTime = Time.time; // Инициализируем время последнего спавна
    }

    private void Update()
    {
        // Проверяем, прошло ли достаточное время с последнего спавна
        if (Time.time - lastSpawnTime >= spawnInterval)
        {
            SpawnObject(); // Спавним новый объект
            lastSpawnTime = Time.time; // Обновляем время последнего спавна
        }

        // Двигаем все активные объекты влево
        foreach (GameObject spawnedObject in objectsToSpawn)
        {
            if (spawnedObject.activeInHierarchy)
            {
                spawnedObject.transform.Translate(Vector3.left * objectSpeed * Time.deltaTime);

                // Проверяем, достиг ли объект позиции для удаления
                if (spawnedObject.transform.position.x <= player.transform.position.x + despawnXPositionOffset)
                {
                    DespawnObject(spawnedObject); // Удаляем объект
                }
            }
        }
    }

    private void SpawnObject()
    {
        // Выбираем случайный индекс объекта для спавна
        int randomIndex = Random.Range(0, objectsToSpawn.Length);

        // Получаем случайное значение для спавна по оси Y в пределах диапазона
        float randomYSpawn = Random.Range(player.transform.position.y - randomYSpawnRange, player.transform.position.y + randomYSpawnRange);

        // Ограничиваем значение случайного спавна по Y, чтобы объекты не спавнились слишком высоко или низко
        randomYSpawn = Mathf.Clamp(randomYSpawn, player.transform.position.y - randomYSpawnRange, player.transform.position.y + randomYSpawnRange);

        // Спавним объект с учетом случайной высоты по оси Y
        GameObject spawnedObject = Instantiate(objectsToSpawn[randomIndex], new Vector3(player.transform.position.x + despawnXPositionOffset, randomYSpawn, transform.position.z), Quaternion.identity);
    }

    private void DespawnObject(GameObject despawnedObject)
    {
        // Удаляем объект
        Destroy(despawnedObject);
    }
}
