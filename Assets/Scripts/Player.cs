using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
	public int playerHP;
	public int playerStandGauge;
	public double deffensePercent;

	public InputAction interAction;
	Rigidbody2D rigidbody2d;
	private TeammateManager teammateManager;

	void Start() {
		rigidbody2d = GetComponent<Rigidbody2D>();
		interAction.Enable();
		interAction.performed += FindTeammate;
		teammateManager = FindObjectOfType<TeammateManager>(); // TeammateManager ��������
	}

	void FindTeammate(InputAction.CallbackContext context) {
		// �� �������� Raycast ����
		RaycastHit2D[] hits = {
			Physics2D.Raycast(rigidbody2d.position, Vector2.right, 1.5f, LayerMask.GetMask("Teammate")),
			Physics2D.Raycast(rigidbody2d.position, Vector2.left, 1.5f, LayerMask.GetMask("Teammate")),
			Physics2D.Raycast(rigidbody2d.position, Vector2.up, 1.5f, LayerMask.GetMask("Teammate")),
			Physics2D.Raycast(rigidbody2d.position, Vector2.down, 1.5f, LayerMask.GetMask("Teammate"))
		};

		foreach (var hit in hits) {
			if (hit.collider != null) {
				Teammate teammate = hit.collider.gameObject.GetComponent<Teammate>();
				if (teammate != null && !teammate.IsInMyTeam) // Teammate���� Ȯ���ϰ� ���� �߰����� ���� ���
				{
					Debug.Log(teammate.teammateName + "��(��) ã�ҽ��ϴ�!");
					teammate.IsInMyTeam = true; // ���� �߰� ǥ��
					teammateManager.AddTeammate(teammate); // TeammateManager�� �߰�
					hit.collider.gameObject.SetActive(false); // ��ȣ�ۿ��� "Teammate" ��ü ��Ȱ��ȭ
				}
			}
		}
	}
}
