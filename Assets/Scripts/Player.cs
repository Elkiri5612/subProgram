using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
	public int id;
	public int playerHP;
	public int playerStandGauge;
	public double deffensePercent;
	public bool isExist;

	public InputAction interAction; // ��ȣ�ۿ�Ű
	Rigidbody2D rigidbody2d;
	private TeammateManager teammateManager;
	public TeammateDialogueManager teammateDialogueManager;


	void Start() {

		Screen.SetResolution(1080, 1920, true);
		Screen.SetResolution(Screen.width, (Screen.width * 16) / 9, true); // ȭ�� ���� ����

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
				this.isExist = true;
				Teammate teammate = hit.collider.gameObject.GetComponent<Teammate>();
				if (teammate != null && !teammate.IsInMyTeam) // Teammate���� Ȯ���ϰ� ���� �߰����� ���� ���
				{
					Debug.Log(teammate.teammateName + "��(��) ã�ҽ��ϴ�!");
					teammate.IsInMyTeam = true; // ���� �߰� ǥ��
					//teammateManager.AddTeammate(teammate); // TeammateManager�� �߰�
					teammateDialogueManager.Talk(hit.collider.gameObject, teammate.teammateName);
					hit.collider.gameObject.SetActive(false); // ��ȣ�ۿ��� "Teammate" ��ü ��Ȱ��ȭ
				}
			}
		}
	}

	void Update() {

		if ( (Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Space)) &&  isExist) {
			//teammateDialogueManager.Talk();
		}
	}
}
