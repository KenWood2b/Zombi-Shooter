using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // ����� ��� ������, �� ������� ����� ��������� ������
    public Vector3 offset = new Vector3(0, 5, -10); // �������� ������ ������������ ������
    public float smoothSpeed = 0.125f; // �������� ����������� �������� ������
    public float rotationSpeed = 100f; // �������� �������� ������ ������ ������

    private float currentZoom = 10f; // ������� ��� ������
    private float zoomSpeed = 4f; // �������� ��������� ����
    private float minZoom = 5f; // ����������� ���
    private float maxZoom = 15f; // ������������ ���

    private float pitch = 2f; // ������������ �������� ������ (�����/����)
    private float yaw = 0f; // �������������� �������� ������

    void LateUpdate()
    {
        // ��������� ���� ��� ���� ������
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        // �������� ������ ������ ������ �� ��� Y
        if (Input.GetMouseButton(1)) // ������ ������ ����
        {
            yaw += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        }

        // ������ �������� ������� ������
        Vector3 desiredPosition = target.position - Quaternion.Euler(0, yaw, 0) * Vector3.forward * currentZoom + Vector3.up * pitch;

        // ������� ����������� ������ � �������� �������
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // ������ ������ ������� �� ������
        transform.LookAt(target.position + Vector3.up * pitch);
    }
}
