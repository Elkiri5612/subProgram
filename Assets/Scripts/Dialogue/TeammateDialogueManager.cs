using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TeammateDialogueManager : MonoBehaviour {
	public static TeammateDialogueManager Instance; // �̱��� �ν��Ͻ�

	public GameObject dialoguePanel; // ��ȭ �г�
	public TMP_Text talkText; // ��ȭ �ؽ�Ʈ UI
	public DialogueText dialogueText; // ��� ������
	public GameObject talkingObject; // ���� ��ȭ ���� ��ü (Monster/Teammate)
	public int textIndex = 0; // ��� �ε���
	public bool isTalking = false; // ��ȭ �� ���� �÷���

	private bool canProceed = true; // ��� �Է� ���� ����

	private void Awake() {
		// �̱��� �ʱ�ȭ
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� ����
		} else {
			Destroy(gameObject); // �ߺ��� �ν��Ͻ� ����
		}
	}

	// ��ȭ ���� �޼���
	public void ProgressDialogue(GameObject TalkingObject) {
		if (this.talkingObject != TalkingObject) {
			// ���ο� ��ȭ ����
			this.talkingObject = TalkingObject;
			textIndex = 0; // �ε��� �ʱ�ȭ
			dialoguePanel.SetActive(true); // ��ȭ �г� Ȱ��ȭ
			isTalking = true; // ��ȭ �� ���� ����
		}

		Id objectId = TalkingObject.GetComponent<Id>();
		if (objectId == null) {
			Debug.LogError("��� Id ������Ʈ�� �����ϴ�!");
			return;
		}

		ShowDialogue(objectId.objectId); // ù ��° ��� �ڵ� ���
	}

	private void Update() {
		// ��ȭ ���� ���� �Է��� ó��
		if (isTalking && canProceed && (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))) {
			if (talkingObject != null) {
				Id objectId = talkingObject.GetComponent<Id>();
				ShowDialogue(objectId.objectId); // ��� ����
			}
		}
	}

	// ��� ���
	public void ShowDialogue(int id) {
		string dialogueTemp = dialogueText.GetText(id, textIndex);

		if (dialogueTemp == null) {
			EndDialogue(); // ��ȭ ����
			return;
		}

		// ���� ��� ���
		talkText.text = dialogueTemp;
		textIndex++;

		// ���� �Է��� �Ͻ������� ����
		StartCoroutine(WaitBeforeNextDialogue());
	}

	// �Է� ���� �ð� ����
	private IEnumerator WaitBeforeNextDialogue() {
		canProceed = false;
		yield return new WaitForSeconds(0.1f); // 0.1�� �� �Է� ����
		canProceed = true;
	}

	// ��ȭ ���� ó��
	public void EndDialogue() {
		dialoguePanel.SetActive(false); // �г� ��Ȱ��ȭ
		textIndex = 0; // �ε��� �ʱ�ȭ
		talkingObject.SetActive(false); // ��ȣ�ۿ� ��� ��Ȱ��ȭ
		isTalking = false; // ��ȭ �� ���� ����

		// ��ȭ ����� Monster���� Ȯ��
		if (talkingObject != null && talkingObject.GetComponent<Monster>() != null) {
			Debug.Log("Monster�� ��ȭ ���� -> Battle ������ ��ȯ");
			SceneManager.LoadScene("Battle"); // Battle �� ��ȯ
		}

		talkingObject = null; // ��ȭ ��� �ʱ�ȭ
	}
}
