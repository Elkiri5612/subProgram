using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillButtonManager : MonoBehaviour
{
    public List<Button> buttons; // SkillPanel�� ��ư ����Ʈ

    void Start()
    {
        // ���� �� ��� ��ư ��Ȱ��ȭ
        DisableAllButtons();
    }

    public void DisableAllButtons()
    {
        foreach (var button in buttons)
        {
            button.gameObject.SetActive(false); // ��� ��ư ��Ȱ��ȭ
        }
    }

    public void ActivateSkillButtons()
    {
        Debug.Log("ActivateSkillButtons() ȣ���");

        for (int i = 0; i < buttons.Count; i++)
        {
            Button button = buttons[i];
            Debug.Log($"��ư Ȱ��ȭ: {button.name}");
            button.gameObject.SetActive(true);

            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.text = $"Skill {i + 1}";
            }

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => OnSkillButtonClicked(i + 1));
        }
    }


    private void OnSkillButtonClicked(int skillNumber)
    {
        Debug.Log($"Skill {skillNumber} ��ư Ŭ����");
    }
}
