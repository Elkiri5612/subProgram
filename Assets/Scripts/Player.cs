using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
	public InputAction interAction; // ��ȣ�ۿ� Ű
	Rigidbody2D rigidbody2d;
	public TeammateDialogueManager teammateDialogueManager; // ��ȭ �Ŵ���
	public GameObject scanObject; // ���� ��ȣ�ۿ� ���

	void Start() {
		rigidbody2d = GetComponent<Rigidbody2D>();
		interAction.Enable(); // �Է� Ȱ��ȭ
		interAction.performed += OnInterAction; // ��ȣ�ۿ� Ű �Է� ����
	}

	void Update() {
		FindTeammate(); // �� �����Ӹ��� �ֺ� ���� ����
	}

	void FindTeammate() {
		RaycastHit2D[] hits = {
			Physics2D.Raycast(rigidbody2d.position, Vector2.right, 1.5f, LayerMask.GetMask("Teammate")),
			Physics2D.Raycast(rigidbody2d.position, Vector2.left, 1.5f, LayerMask.GetMask("Teammate")),
			Physics2D.Raycast(rigidbody2d.position, Vector2.up, 1.5f, LayerMask.GetMask("Teammate")),
			Physics2D.Raycast(rigidbody2d.position, Vector2.down, 1.5f, LayerMask.GetMask("Teammate"))
		};

		foreach (var hit in hits) {
			if (hit.collider != null) {
				scanObject = hit.collider.gameObject;
				return;
			}
		}
		scanObject = null; // ������ ������ ������ �ʱ�ȭ
	}

	void OnInterAction(InputAction.CallbackContext context) {
		if (scanObject != null) {
			teammateDialogueManager.ProgressDialogue(scanObject);
		}
	}
}
