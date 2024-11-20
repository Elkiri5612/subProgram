using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public List<Button> buttons; // TeammatePanel ��ư ����Ʈ
    private BattleManager battleManager;


    [SerializeField] private SkillButtonManager skillButtonManager; // SkillButtonManager ����

    private void Start()
    {
        battleManager = BattleManager.Instance;

        if (battleManager == null)
        {
            Debug.LogError("BattleManager�� ã�� �� �����ϴ�!");
            return;
        }

        // SkillButtonManager �ڵ� �˻�
        if (skillButtonManager == null)
        {
            skillButtonManager = FindObjectOfType<SkillButtonManager>();
            if (skillButtonManager == null)
            {
                Debug.LogError("SkillButtonManager�� ã�� �� �����ϴ�! Unity �����Ϳ��� �������� �����ϰų� ��ũ��Ʈ�� Ȯ���ϼ���.");
                return;
            }
        }

        UpdateButtons();
    }
    public void UpdateButtons()
    {
        List<Teammate> teammates = battleManager.battleTeammates;

        if (teammates == null || teammates.Count == 0)
        {
            Debug.LogWarning("BattleManager�� ���� �����Ͱ� �����ϴ�.");
            foreach (var button in buttons)
            {
                button.gameObject.SetActive(false);
            }
            return;
        }

        int buttonIndex = 0;
        foreach (var teammate in teammates)
        {
            if (buttonIndex >= buttons.Count)
            {
                Debug.LogWarning("TeammatePanel ��ư�� �����մϴ�.");
                break;
            }

            Button button = buttons[buttonIndex];
            button.gameObject.SetActive(true);

            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.text = teammate.teammateName;
            }

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => OnTeammateButtonClicked(teammate));

            buttonIndex++;
        }

        for (int i = buttonIndex; i < buttons.Count; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }

        Canvas.ForceUpdateCanvases();
    }

    private void OnTeammateButtonClicked(Teammate teammate)
    {
        Debug.Log($"{teammate.teammateName} ��ư Ŭ����");

        if (skillButtonManager != null)
        {
            Debug.Log("SkillButtonManager�� ���������� ����Ǿ����ϴ�.");
            skillButtonManager.ActivateSkillButtons(teammate); // ���� ���� ����
        }
        else
        {
            Debug.LogError("SkillButtonManager�� ������� �ʾҽ��ϴ�!");
        }
    }
}