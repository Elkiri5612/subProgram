using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillButtonManager : MonoBehaviour
{
    public List<Button> buttons; // �̹� ������ ��ư ����Ʈ

    void Start()
    {
        // ���� �� ��� ��ư ��Ȱ��ȭ
        DisableAllButtons();
    }

    public void DisableAllButtons()
    {
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(false); // ��ư ��Ȱ��ȭ
        }
    }

    public void ActivateSkillButtons(Teammate teammate)
    {
        Debug.Log("ActivateSkillButtons() ȣ���");

        if (teammate == null)
        {
            Debug.LogWarning("�ش� ���ᰡ �������� �ʽ��ϴ�.");
            DisableAllButtons();
            return;
        }

        // ��ų�� ���� ��� �ʱ�ȭ
        if (teammate.skills.Count == 0)
        {
            switch (teammate.teammateName)
            {
                case "kimsubin":
                    teammate.skills.Add(new Skill("�������� �̵�", 110, 0.0, 0));
                    teammate.skills.Add(new Skill("������ ��ġ", 180, 0.0, 0));
                    teammate.skills.Add(new Skill("��Ÿ �÷�Ƽ�� ����", 430, 0.0, 0));
                    break;
            }
        }

        // ��ų ��ư ����
        for (int i = 0; i < buttons.Count; i++)
        {
            if (i < teammate.skills.Count)
            {
                Button button = buttons[i];
                button.gameObject.SetActive(true);

                TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
                if (buttonText != null)
                {
                    buttonText.text = teammate.skills[i].skillName;
                }

                int skillIndex = i; // Ŭ���� ���� ����
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => OnSkillButtonClicked(teammate.skills[skillIndex]));

                Debug.Log($"��ư {i + 1} Ȱ��ȭ: {teammate.skills[i].skillName}");
            }
            else
            {
                buttons[i].gameObject.SetActive(false);
                Debug.Log($"��ư {i + 1} ��Ȱ��ȭ");
            }
        }
    }

    private void OnSkillButtonClicked(Skill skill)
    {
        Debug.Log($"��ų '{skill.skillName}' ��ư Ŭ����");
        // ��ų ��� ���� ����
    }
}
