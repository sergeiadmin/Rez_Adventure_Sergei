using UnityEngine;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour
{
    public Text distanceText; // —сылка на текстовое поле, отображающее пройденное рассто€ние
    private Transform playerTransform; // —сылка на трансформ игрока
    private Vector3 lastPosition; // ѕоследн€€ позици€ игрока

    private float totalDistance = 0f; // ќбщее пройденное рассто€ние

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Ќаходим игрока по тегу
        lastPosition = playerTransform.position; // —охран€ем изначальную позицию игрока
        UpdateDistanceText(); // ќбновл€ем текстовое поле с начальным значением рассто€ни€
    }

    private void Update()
    {
        // ¬ычисл€ем пройденное рассто€ние как разницу между текущей позицией и последней позицией игрока
        float distanceDelta = playerTransform.position.x - lastPosition.x;
        totalDistance += Mathf.Abs(distanceDelta); // ѕрибавл€ем абсолютное значение разницы (чтобы игнорировать движение назад)

        // ќбновл€ем последнюю позицию игрока
        lastPosition = playerTransform.position;

        // ќбновл€ем текстовое поле с пройденным рассто€нием
        UpdateDistanceText();
    }

    private void UpdateDistanceText()
    {
        distanceText.text = "–ассто€ние: " + totalDistance.ToString("F1") + " m"; // ќбновл€ем текстовое поле с текущим значением пройденного рассто€ни€
    }
}
