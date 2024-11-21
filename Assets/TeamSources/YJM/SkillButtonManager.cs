using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillButtonManager : MonoBehaviour
{
    public List<Button> skillButtons = new List<Button>(); // �̹� ������ ��ư ����Ʈ

    void Start()
    {
        // ���� �� ��� ��ư ��Ȱ��ȭ
        DisableAllButtons();
    }

    public void DisableAllButtons()
    {
        foreach (var button in skillButtons)
        {
            button.gameObject.SetActive(false); // ��ư ��Ȱ��ȭ
        }
    }

    public void ActivateSkillButtons(Teammate teammate)
    {
        if (Object.ReferenceEquals(teammate, null))
        {
            Debug.LogError("���޵� Teammate�� Unity���� �����Ǿ����ϴ�.");
            DisableAllButtons();
            return;
        }

        Teammate ActiveTeammate = teammate;

        Debug.Log($"ActivateSkillButtons ȣ��: �̸� = {ActiveTeammate.teammateName}, ü�� = {ActiveTeammate.maxHP}, ��ų ���� = {ActiveTeammate.skills?.Count ?? 0}");

        if (ActiveTeammate.skills == null || ActiveTeammate.skills.Count == 0)
        {
            Debug.LogWarning($"{ActiveTeammate.teammateName}���� ��ų�� �����ϴ�.");
            DisableAllButtons();
            return;
        }

        for (int i = 0; i < skillButtons.Count; i++)
        {
            if (i < ActiveTeammate.skills.Count)
            {
                Button button = skillButtons[i];
                button.gameObject.SetActive(true);

                TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
                if (buttonText != null)
                {
                    buttonText.text = ActiveTeammate.skills[i].skillName;
                }

                Teammate capturedTeammate = ActiveTeammate;
                int capturedIndex = i; // Ŭ���� ���� ����
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => OnSkillButtonClicked(capturedTeammate.skills[capturedIndex]));

                Debug.Log($"��ư {i + 1} Ȱ��ȭ: {ActiveTeammate.skills[i].skillName}");
            }
            else
            {
                skillButtons[i].gameObject.SetActive(false);
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
