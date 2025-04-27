using UnityEngine;


public class PrefabSpawner : MonoBehaviour
{
    // Сериализуем поле для выбора префабов
    [SerializeField]
    private GameObject[] prefabOptions; // Массив префабов

    [SerializeField]
    private float spawnRadius = 1f; // Радиус, в котором будет происходить спавн на спрайте

    private BoxCollider2D spriteCollider; // Коллайдер объекта с спрайтом

    void Start()
    {
        // Получаем коллайдер спрайта
        spriteCollider = GetComponent<BoxCollider2D>();
        
        if (spriteCollider == null)
        {
            Debug.LogWarning("Коллайдер не найден! Необходимо добавить BoxCollider2D на объект с спрайтом.");
            return;
        }
        
        // Вызываем функцию спавна при старте
        SpawnRandomPrefab();
    }

    public void SpawnRandomPrefab()
    {
        if (prefabOptions.Length == 0)
        {
            Debug.LogWarning("Нет префабов для спавна.");
            return;
        }

        // Выбираем случайный префаб
        GameObject prefabToSpawn = prefabOptions[Random.Range(0, prefabOptions.Length)];

        // Находим самую нижнюю точку объекта с помощью коллайдера
        Vector3 spawnPosition = new Vector3(
            transform.position.x + Random.Range(-spawnRadius, spawnRadius), 
            transform.position.y - spriteCollider.bounds.size.y / 2, // Низ коллайдера
            transform.position.z
        );

        // Спавним префаб в найденной точке
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}