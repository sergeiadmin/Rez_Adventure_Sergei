using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // ������ �������� ��� ������
    public float spawnInterval = 2f; // �������� ����� ��������
    public float objectSpeed = 3f; // �������� �������� ��������
    public float despawnXPositionOffset = -40f; // ������ ��� �������� �������� �� ��������� ������ �� ��� X
    public float randomYSpawnRange = 5f; // �������� ���������� ������ �� ������ (��� Y)
    public GameObject player; // ������ �� ������

    private float lastSpawnTime; // ����� ���������� ������

    private void Start()
    {
        lastSpawnTime = Time.time; // �������������� ����� ���������� ������
    }

    private void Update()
    {
        // ���������, ������ �� ����������� ����� � ���������� ������
        if (Time.time - lastSpawnTime >= spawnInterval)
        {
            SpawnObject(); // ������� ����� ������
            lastSpawnTime = Time.time; // ��������� ����� ���������� ������
        }

        // ������� ��� �������� ������� �����
        foreach (GameObject spawnedObject in objectsToSpawn)
        {
            if (spawnedObject.activeInHierarchy)
            {
                spawnedObject.transform.Translate(Vector3.left * objectSpeed * Time.deltaTime);

                // ���������, ������ �� ������ ������� ��� ��������
                if (spawnedObject.transform.position.x <= player.transform.position.x + despawnXPositionOffset)
                {
                    DespawnObject(spawnedObject); // ������� ������
                }
            }
        }
    }

    private void SpawnObject()
    {
        // �������� ��������� ������ ������� ��� ������
        int randomIndex = Random.Range(0, objectsToSpawn.Length);

        // �������� ��������� �������� ��� ������ �� ��� Y � �������� ���������
        float randomYSpawn = Random.Range(player.transform.position.y - randomYSpawnRange, player.transform.position.y + randomYSpawnRange);

        // ������������ �������� ���������� ������ �� Y, ����� ������� �� ���������� ������� ������ ��� �����
        randomYSpawn = Mathf.Clamp(randomYSpawn, player.transform.position.y - randomYSpawnRange, player.transform.position.y + randomYSpawnRange);

        // ������� ������ � ������ ��������� ������ �� ��� Y
        GameObject spawnedObject = Instantiate(objectsToSpawn[randomIndex], new Vector3(player.transform.position.x + despawnXPositionOffset, randomYSpawn, transform.position.z), Quaternion.identity);
    }

    private void DespawnObject(GameObject despawnedObject)
    {
        // ������� ������
        Destroy(despawnedObject);
    }
}
