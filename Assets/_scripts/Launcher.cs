using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject bombPrefab;
    public Camera mainCamera;
    public float minHeight = 1f; // Минимальная высота для спавна бомбы
    public float spawnHeight = 10f; // Высота, на которой будет спавниться бомба, если курсор ниже minHeight

    void Update()
    {
        // Делаем так, чтобы спрайт лаунчера следовал за курсором
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Сохраняем спрайт на плоскости 2D

        transform.position = mousePosition;

        // Спавним бомбу при клике
        if (Input.GetMouseButtonDown(0))
        {
            // Получаем позицию клика на экране
            Vector3 spawnPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0f; // Убираем влияние на Z-координату

            // Если курсор ниже минимальной высоты, спавним на заданной высоте
            if (spawnPosition.y < minHeight)
            {
                spawnPosition.y = spawnHeight; // Спавним на фиксированной высоте
            }

            // Спавним бомбу
            Instantiate(bombPrefab, spawnPosition, Quaternion.identity);
        }
    }
}