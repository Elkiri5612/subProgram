using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleUI : MonoBehaviour
{
    public GameObject buttonPrefab;      // ��ư�� ������
    public Transform buttonContainer;    // ��ư���� ��ġ�� �θ� ��ü
    public TextMeshProUGUI battleStatusText; // ��Ʋ ���� �ؽ�Ʈ

    private BattleManager battleManager; // BattleManager�� ����

    void Start()
    {
        // BattleManager�� Singleton �ν��Ͻ��� ���
        battleManager = BattleManager.Instance;

        if (battleManager != null)
        {
            Debug.Log("BattleManager�� ã�ҽ��ϴ�.");
            // ���� ������ �°� ��ư�� �������� ����
            GenerateTeammateButtons();
        }
        else
        {
            Debug.LogError("BattleManager�� ã�� �� �����ϴ�.");
        }
    }

    // ������� ������ �������� ��ư�� �����ϴ� �޼���
    void GenerateTeammateButtons()
    {
        // ��ư�� ������ �θ� ��ü �ʱ�ȭ (���� ��ư���� ����)
        foreach (Transform child in buttonContainer)
        {
            Destroy(child.gameObject);  // ���� ��ư ����
        }

        // ��Ʋ�� �����ϴ� ����� ��� ��������
        if (battleManager != null && battleManager.battleTeammates.Count > 0)
        {
            Debug.Log("��Ʋ�� �����ϴ� ���� ��: " + battleManager.battleTeammates.Count); // ���� �� Ȯ��
            foreach (Teammate teammate in battleManager.battleTeammates)
            {
                // ��ư ����
                GameObject newButton = Instantiate(buttonPrefab, buttonContainer);

                // ��ư�� �ؽ�Ʈ ������Ʈ (���� �̸�)
                TextMeshProUGUI buttonText = newButton.GetComponentInChildren<TextMeshProUGUI>();  // TextMeshProUGUI�� ����
                if (buttonText != null)
                {
                    buttonText.text = teammate.teammateName;  // ���� �̸��� �ؽ�Ʈ�� ����
                }
                else
                {
                    Debug.LogError("��ư�� TextMeshProUGUI ������Ʈ�� �����ϴ�.");
                }

                // ��ư�� Ŭ�� �̺�Ʈ �߰�
                Button button = newButton.GetComponent<Button>();
                if (button != null)
                {
                    button.onClick.AddListener(() => OnTeammateButtonClick(teammate));
                    Debug.Log("��ư Ŭ�� �̺�Ʈ ��ϵ�: " + teammate.teammateName);
                }
                else
                {
                    Debug.LogError("��ư�� Button ������Ʈ�� �����ϴ�.");
                }
            }

            // ��Ʋ ���� �ؽ�Ʈ ������Ʈ
            battleStatusText.text = "��Ʋ �غ� ��...";
        }
        else
        {
            Debug.LogError("��Ʋ�� �����ϴ� ���ᰡ �����ϴ�.");
        }
    }

    // ���� ��ư Ŭ�� �� ȣ��Ǵ� �޼���
    void OnTeammateButtonClick(Teammate clickedTeammate)
    {
        Debug.Log(clickedTeammate.teammateName + "�� ��ư�� Ŭ���Ǿ����ϴ�.");
        // Ŭ���� ���ῡ ���� �߰� ���� (��: ��ų ���, ���� ��)
        StartBattleWithTeammate(clickedTeammate);
    }

    // ����: Ŭ���� ����� ��Ʋ ����
    void StartBattleWithTeammate(Teammate teammate)
    {
        // ��Ʋ ���� ���� (���ῡ ���� �ൿ �߰�)
        Debug.Log(teammate.teammateName + "�� ��Ʋ�� �����մϴ�.");
    }
}
