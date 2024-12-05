using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeammateDialogueManager : MonoBehaviour {
	public GameObject dialoguePanel; // ��ȭ �г�
	public TMP_Text talkText; // ��ȭ �ؽ�Ʈ UI
	public DialogueText dialogueText; // ��� ������
	public GameObject talkingTeammate; // ���� ��ȭ ���� ����
	public int textIndex = 0; // ��� �ε���

	public void ProgressDialogue(GameObject talkingTeammate) {
		if (this.talkingTeammate != talkingTeammate) {
			// ���ο� ������ ��ȭ ����
			this.talkingTeammate = talkingTeammate;
			textIndex = 0; // �ε��� �ʱ�ȭ
			dialoguePanel.SetActive(true); // ��ȭ �г� Ȱ��ȭ
		}

		Id teammateId = talkingTeammate.GetComponent<Id>();
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
		talkingTeammate.SetActive(false); // ��ȣ�ۿ� ��� ��Ȱ��ȭ
		talkingTeammate = null; // ���� �ʱ�ȭ
	}
}
