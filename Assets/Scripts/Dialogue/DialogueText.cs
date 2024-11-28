using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueText : MonoBehaviour {
	Dictionary<int, string[]> talkText;

	private void Awake() {
		talkText = new Dictionary<int, string[]>();
		GenerateText();
	}

	void GenerateText() {
		// ���� ��ȭ ������
		talkText.Add(1, new string[] { "������? ���⼭ �� �ϰ� �ִ� ����?", "��, �λ����̶��? �׵� �ɷδ� ���� �������� �ʾ�.", "��. ��... �׷��Ա��� ���� �ʿ��ϴٸ��. ����." });
		talkText.Add(2, new string[] { "�� �����, ������ �ƹ�!", "Yo, �ο��� ���� ���� ����!", "��~ Yeah~ ���� �� �̲���!" });
	}

	public string GetText(int id, int textIndex) {
		if (!talkText.ContainsKey(id)) {
			Debug.LogError($"ID {id}�� �ش��ϴ� ��簡 �����ϴ�.");
			return null;
		}

		if (textIndex >= talkText[id].Length) {
			return null; // ��ȭ ��
		}

		return talkText[id][textIndex];
	}
}
