using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InputAction interAction;
    private Rigidbody2D rigidbody2d;
    Vector2 moveDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        interAction.Enable();
        interAction.performed += FindTeammate;
    }

    void FindTeammate(InputAction.CallbackContext context) {
        RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.35f, moveDirection, 1.5f, LayerMask.GetMask("Teammate"));
    if (hit.collider != null) {
            Debug.Log("Raycast has hit the object " + hit.collider.gameObject);


            // ���⿡ ��ȭ â �߰� �ϱ�

			hit.collider.gameObject.SetActive(false); // ��ȣ�ۿ��� "Teammate" ���̾� ��ü ������� �ϱ�
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
