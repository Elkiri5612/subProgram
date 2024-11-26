using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public List<Button> buttons; // TeammatePanel ��ư ����Ʈ
    private BattleManager battleManager;

    public List<Teammate> teammates = new List<Teammate>();

    [SerializeField] private SkillButtonManager skillButtonManager; // SkillButtonManager ����

    private void Start()
    {
        // BattleManager�� �̱��� �ν��Ͻ� ��������
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

        UpdateButtons(); // ���� �����͸� ������� ��ư ������Ʈ
    }

    public void UpdateButtons()
    {
        // BattleManager���� ���� �����͸� ������
        List<Teammate> teammates = new List<Teammate>(battleManager.battleTeammates);
        Debug.Log($"�̸�: {teammates[0].teammateName}, ü��: {teammates[0].maxHP}, ���ݷ�: {teammates[0].attackPercent}, ��ų: {teammates[0].skills}");
        if (teammates == null || teammates.Count == 0)
        {
            Debug.LogWarning("BattleManager�� ���� �����Ͱ� �����ϴ�.");
            foreach (var button in buttons)
            {
                button.gameObject.SetActive(false); // ��ư ��Ȱ��ȭ
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
                buttonText.text = teammate.teammateName; // ��ư �ؽ�Ʈ ������Ʈ
            }

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => OnTeammateButtonClicked(teammate)); // Ŭ�� �̺�Ʈ ����

            buttonIndex++;
        }

        // ���� ��ư ��Ȱ��ȭ
        for (int i = buttonIndex; i < buttons.Count; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }

        Canvas.ForceUpdateCanvases(); // UI ����
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
