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
			talkText.text = "���ϴ� ������ �̸��� " + teammateName;
		// }

		dialoguePanel.SetActive(IsTalking);
		
	}

	
}
