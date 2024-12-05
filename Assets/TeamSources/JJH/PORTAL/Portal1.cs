using UnityEngine;

public class Portal : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(10.77f, 0.35f, 0.0007217824f);  // ��ǥ ��ġ
    public string targetSceneName;    // �� ��ȯ�� ����� ��� �� �̸�

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // "Player" �±װ� �ִ� ��ü�� �����ϵ��� ��
        if (collision.CompareTag("Player"))
        {
            // ��ǥ ��ġ�� �̵�
            collision.transform.position = targetPosition;
            Debug.Log("��Ż�� ���� �̵��߽��ϴ�: " + targetPosition);
        }
    }
}
