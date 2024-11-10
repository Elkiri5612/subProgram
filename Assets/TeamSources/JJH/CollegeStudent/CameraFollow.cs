using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ī�޶� ���� ��� (ĳ����)
    public Vector3 offset; // ī�޶�� ��� ������ �Ÿ�
    public float smoothSpeed = 0.125f; // ī�޶� �̵� �ӵ� (�ε巴�� �̵�)

    private void LateUpdate()
    {
        if (target != null)
        {
            // Ÿ�� ��ġ�� �������� �߰��� ��ġ�� ī�޶� �̵�
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}


