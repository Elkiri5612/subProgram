using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillButtonManager : MonoBehaviour
{
    public List<Button> skillButtons = new List<Button>(); // �̹� ������ ��ư ����Ʈ
    public BattleManager battleManager;
    public Teammate ActiveTeammate;
    public Skill skill;
    void Start()
    {
        battleManager = BattleManager.Instance;
        if (battleManager == null)
        {
            Debug.LogError("BattleManager�� �ʱ�ȭ���� �ʾҽ��ϴ�!");
        }

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

        ActiveTeammate = teammate;

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

                
                int capturedIndex = i; // Ŭ���� ���� ����
                
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => OnSkillButtonClicked(ActiveTeammate,ActiveTeammate.skills[capturedIndex]));

                Debug.Log($"��ư {i + 1} Ȱ��ȭ: {ActiveTeammate.skills[i].skillName}");
            }
            else
            {
                skillButtons[i].gameObject.SetActive(false);
                Debug.Log($"��ư {i + 1} ��Ȱ��ȭ");
            }
        }
    }


    public void OnSkillButtonClicked(Teammate Teammate, Skill skill)
    {
        Debug.Log($"OnSkillButtonClickedȣ��: �̸� = {Teammate.teammateName}, ü�� = {Teammate.maxHP}, ��ų ���� = {Teammate.skills?.Count ?? 0}");
        if (!Teammate.stun)
        {
            Debug.Log($"��ų '{skill.skillName}' ��ư Ŭ����");
            Debug.Log($"��ų�� ���� : �̸� : {skill.skillName}, ���ݷ� : {skill.attackDamage}, ���� ���� : {skill.defensePercent}, ���� : {skill.buffConst} ");
            /*if (Teammate == null)
            {
                Debug.LogError("SkillButtonManager���� ���޵� teammate�� null�Դϴ�!");
            }*/

            if (skill == null)
            {
                Debug.LogError("SkillButtonManager���� ���޵� skill�� null�Դϴ�!");
            }

            if (Teammate.standGauge - skill.usingStandGauge >= 0)
            {
                BattleManager.Instance.ApplySkillDamage(Teammate, skill);
            }
            else
            {
                Debug.Log($"{Teammate.teammateName}�� ���ĵ� �������� �����մϴ�!!");
            }
        }
        else
        {
            Debug.Log($"{Teammate.teammateName}�� ���������Դϴ�!");
        }
        // ��ų ��� ���� ����
    }
}
