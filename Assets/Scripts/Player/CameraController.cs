using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // Игрок или объект, за которым будет следовать камера
    public Vector3 offset = new Vector3(0, 5, -10); // Смещение камеры относительно игрока
    public float smoothSpeed = 0.125f; // Скорость сглаживания движения камеры
    public float rotationSpeed = 100f; // Скорость вращения камеры вокруг игрока

    private float currentZoom = 10f; // Текущий зум камеры
    private float zoomSpeed = 4f; // Скорость изменения зума
    private float minZoom = 5f; // Минимальный зум
    private float maxZoom = 15f; // Максимальный зум

    private float pitch = 2f; // Вертикальное смещение камеры (вверх/вниз)
    private float yaw = 0f; // Горизонтальное вращение камеры

    void LateUpdate()
    {
        // Прокрутка мыши для зума камеры
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        // Вращение камеры вокруг игрока по оси Y
        if (Input.GetMouseButton(1)) // Правая кнопка мыши
        {
            yaw += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        }

        // Расчет желаемой позиции камеры
        Vector3 desiredPosition = target.position - Quaternion.Euler(0, yaw, 0) * Vector3.forward * currentZoom + Vector3.up * pitch;

        // Плавное перемещение камеры к желаемой позиции
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Камера всегда смотрит на игрока
        transform.LookAt(target.position + Vector3.up * pitch);
    }
}
