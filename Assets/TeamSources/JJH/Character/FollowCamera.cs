using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // ����ٴ� ��� (ĳ����)
    public float smoothSpeed = 0.125f; // ī�޶� �̵� �ӵ�
    public Vector3 offset; // ī�޶�� ĳ���� ������ �Ÿ�

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
