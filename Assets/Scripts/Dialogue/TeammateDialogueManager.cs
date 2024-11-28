using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TeammateDialogueManager : MonoBehaviour {

	public GameObject dialoguePanel;
	public bool IsTalking;
	public TMP_Text talkText; // Inspector���� �Ҵ�
	public GameObject talkingTeammate;
	public DialogueText dialogueText;

	public int teammateId;
	public int textIndex;

	public void Talk(GameObject talkingTeammate, string teammateName) {
		/*
		if (talkText == null) {
			Debug.LogError("talkText�� Inspector���� �Ҵ���� �ʾҽ��ϴ�!");
			return;
		} 

		if (talkingTeammate == null) {
			Debug.LogError("talkingTeammate�� null�Դϴ�! ��ȿ�� GameObject�� �����ϼ���.");
			return;
		} */

		// if (IsTalking) {
		//	IsTalking = false;
		// } else {
			IsTalking = true;
			this.talkingTeammate = talkingTeammate;
			// teammateId = talkingTeammate.id;
			talkText.text = "���ϴ� ������ �̸��� " + teammateName;
		// }

		dialoguePanel.SetActive(IsTalking);
		
	}

	public void getDialogueText() {
		dialogueText.GetText(teammateId, textIndex);
	}

	
}
