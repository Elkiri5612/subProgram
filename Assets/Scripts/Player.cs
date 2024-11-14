using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public int playerHP; // ������ ����
    public int playerStandGauge; // �����߻�
    public double deffensePercent;

    public InputAction interAction;
    Rigidbody2D rigidbody2d;

	// Vector2 rightDirection = new Vector2(1, 0);


	// Start is called before the first frame update
	void Start(){

        rigidbody2d = GetComponent<Rigidbody2D>();
        interAction.Enable();
        interAction.performed += FindTeammate;
    }

	// Update is called once per frame
	void Update() {

	}

	void FindTeammate(InputAction.CallbackContext context) {
		// RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.40f, moveDirection, 1.5f, LayerMask.GetMask("Teammate"));
		RaycastHit2D hitR = Physics2D.Raycast(rigidbody2d.position, Vector2.right, 1.5f, LayerMask.GetMask("Teammate"));
		RaycastHit2D hitL = Physics2D.Raycast(rigidbody2d.position, Vector2.left, 1.5f, LayerMask.GetMask("Teammate"));
		RaycastHit2D hitU = Physics2D.Raycast(rigidbody2d.position, Vector2.up, 1.5f, LayerMask.GetMask("Teammate"));
		RaycastHit2D hitD = Physics2D.Raycast(rigidbody2d.position, Vector2.down, 1.5f, LayerMask.GetMask("Teammate"));


		if (hitR.collider != null) {
            Debug.Log("Raycast has hit the object " + hitR.collider.gameObject);


			// ���⿡ ��ȭ â �߰� �ϱ�
			hitR.collider.gameObject.SetActive(false); // ��ȣ�ۿ��� "Teammate" ���̾� ��ü ������� �ϱ�
		}

		if (hitL.collider != null) {
			Debug.Log("Raycast has hit the object " + hitL.collider.gameObject);


			// ���⿡ ��ȭ â �߰� �ϱ�
			hitL.collider.gameObject.SetActive(false); // ��ȣ�ۿ��� "Teammate" ���̾� ��ü ������� �ϱ�
		}

		if (hitU.collider != null) {
			Debug.Log("Raycast has hit the object " + hitU.collider.gameObject);


			// ���⿡ ��ȭ â �߰� �ϱ�
			hitU.collider.gameObject.SetActive(false); // ��ȣ�ۿ��� "Teammate" ���̾� ��ü ������� �ϱ�
		}

		if (hitD.collider != null) {
			Debug.Log("Raycast has hit the object " + hitD.collider.gameObject);


			// ���⿡ ��ȭ â �߰� �ϱ�
			hitD.collider.gameObject.SetActive(false); // ��ȣ�ۿ��� "Teammate" ���̾� ��ü ������� �ϱ�
		}
	}

    
}
