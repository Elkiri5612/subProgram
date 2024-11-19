using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TeammateDialogueManager : MonoBehaviour {
	public TMP_Text talkText; // Inspector���� �Ҵ�
	public GameObject talkingTeammate;

	public void Talk(GameObject talkingTeammate, string teammateName) {
		if (talkText == null) {
			Debug.LogError("talkText�� Inspector���� �Ҵ���� �ʾҽ��ϴ�!");
			return;
		}

		if (talkingTeammate == null) {
			Debug.LogError("talkingTeammate�� null�Դϴ�! ��ȿ�� GameObject�� �����ϼ���.");
			return;
		}

		this.talkingTeammate = talkingTeammate;
		talkText.text = "���ϴ� ������ �̸��� " + teammateName;
	}
}
