using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeammateDialogueManager : MonoBehaviour {

	public static TeammateDialogueManager Instance;

	public GameObject dialoguePanel; // ��ȭ �г�
	public TMP_Text talkText; // ��ȭ �ؽ�Ʈ UI
	public DialogueText dialogueText; // ��� ������
	public GameObject talkingObject; // ���� ��ȭ ���� ����
	public int textIndex = 0; // ��� �ε���
	private bool isTalking = false;

	// public TeammateManager tempTeammateManager;


	public void ProgressDialogue(GameObject TalkingObject) {

		if (this.talkingObject != TalkingObject) {
			// ���ο� ������ ��ȭ ����
			this.talkingObject = TalkingObject;
			// Teammate tempTeammate = talkingTeammate.GetComponent<Teammate>();
			// tempTeammateManager.teammates.Add(tempTeammate);
			textIndex = 0; // �ε��� �ʱ�ȭ
			dialoguePanel.SetActive(true); // ��ȭ �г� Ȱ��ȭ

		}

		Id teammateId = TalkingObject.GetComponent<Id>();
		if (teammateId == null) {
			Debug.LogError("Teammate�� Id ������Ʈ�� �����ϴ�!");
			return;
		}

		ShowDialogue(teammateId.objectId);
	}

	public void ShowDialogue(int id) {
		string dialogueTemp = dialogueText.GetText(id, textIndex);

		if (dialogueTemp == null) {
			// ��ȭ ����
			EndDialogue();
			return;
		}

		// ���� ��� ���
		talkText.text = dialogueTemp;
		textIndex++;
	}

	void EndDialogue() {
		dialoguePanel.SetActive(false); // �г� ��Ȱ��ȭ
		textIndex = 0; // �ε��� �ʱ�ȭ
		talkingObject.SetActive(false); // ��ȣ�ۿ� ��� ��Ȱ��ȭ
		talkingObject = null; // ���� �ʱ�ȭ
	}

	public void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� ����
		} else {
			Destroy(gameObject); // �ߺ��� �ν��Ͻ� ����
		}
	}
}
