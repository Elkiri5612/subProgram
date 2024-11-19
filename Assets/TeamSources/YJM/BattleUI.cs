using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleUI : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform buttonContainer;    // ��ư �θ� ��ü
    //public TextMeshProUGUI battleStatusText; // ��Ʋ ���� �ؽ�Ʈ

    private BattleManager battleManager;

    void Start()
    {
        battleManager = BattleManager.Instance;

        if (battleManager != null)
        {
            Debug.Log("BattleManager�� ã�ҽ��ϴ�.");
            // ���� ������ �°� ��ư ���� ����
            GenerateTeammateButtons();
        }
        else
        {
            Debug.LogError("BattleManager�� ã�� �� �����ϴ�.");
        }
    }

    // ������ �������� ��ư�� �����ϴ� �޼���
    void GenerateTeammateButtons()
    {
        Debug.Log("GenerateTeammateButtons ����");

        // �θ� ��ü Ȯ��
        if (buttonContainer == null)
        {
            Debug.LogError("buttonContainer�� null�Դϴ�. Inspector���� �Ҵ�Ǿ����� Ȯ���ϼ���.");
            return;
        }


        // �θ� ��ü �ʱ�ȭ (���� ��ư ����)
        foreach (Transform child in buttonContainer)
        {
            Debug.Log("���� ��ư ���� ��: " + child.name);
            Destroy(child.gameObject);
        }

        // BattleManager�� ���� ��� Ȯ��
        if (battleManager == null || battleManager.battleTeammates == null)
        {
            Debug.LogError("battleManager �Ǵ� battleTeammates�� null�Դϴ�.");
            return;
        }

        if (battleManager.battleTeammates.Count == 0)
        {
            Debug.LogError("��Ʋ�� �����ϴ� ���ᰡ �����ϴ�.");
            return;
        }

        Debug.Log("��Ʋ ���� ��: " + battleManager.battleTeammates.Count);

		// ��ư ���� ���� Ȯ�� �÷���
		bool buttonCreated = false;


		// ���� ������ ���� ��ư ����
		foreach (Teammate teammate in battleManager.battleTeammates)
        {
            Debug.Log("���� ��ư ���� ��: " + (teammate.teammateName ?? "�̸� ����"));

            if (buttonPrefab == null)
            {
                Debug.LogError("buttonPrefab�� null�Դϴ�. Inspector���� �Ҵ�Ǿ����� Ȯ���ϼ���.");
                return;
            }

            // ��ư ����
            GameObject newButton = Instantiate(buttonPrefab, buttonContainer);
            
            // ��ư �ؽ�Ʈ ����
            TextMeshProUGUI buttonText = newButton.GetComponentInChildren<TextMeshProUGUI>();

            if (buttonText != null)
            {
                buttonText.text = string.IsNullOrEmpty(teammate.teammateName) ? "�̸� ����" : teammate.teammateName;
            }
            else
            {
                Debug.LogError("buttonPrefab�� TextMeshProUGUI ������Ʈ�� �����ϴ�.");
            }

            // ��ư Ŭ�� �̺�Ʈ ����
            Button button = newButton.GetComponent<Button>();
            if (button != null)
            {
                button.onClick.AddListener(() => OnTeammateButtonClick(teammate));
                Debug.Log("��ư Ŭ�� �̺�Ʈ ��ϵ�: " + teammate.teammateName);
            }
            else
            {
                Debug.LogError("buttonPrefab�� Button ������Ʈ�� �����ϴ�.");
            }

			// ��ư ��ǥ ���
			if (newButton != null) {
				buttonCreated = true; // ��ư�� �����Ǿ����� Ȯ��
				Vector3 buttonPosition = newButton.transform.position;
				Debug.Log($"��ư ������: {teammate.teammateName}, ��ġ: {buttonPosition}");
			}

		}

		// ��ư ���� ���� Ȯ��
		if (!buttonCreated) {
			Debug.LogError("��ư ���� �ȵ�");
		}

		Debug.Log("GenerateTeammateButtons �Ϸ�");

		// ��Ʋ ���� �ؽ�Ʈ ������Ʈ
		/*if (battleStatusText != null)
        {
            battleStatusText.text = "��Ʋ �غ� ��...";
        }
        else
        {
            Debug.LogError("battleStatusText�� null�Դϴ�. Inspector���� �Ҵ�Ǿ����� Ȯ���ϼ���.");
        }

        Debug.Log("GenerateTeammateButtons �Ϸ�");*/
	}

	// ��ư Ŭ�� �� ȣ��Ǵ� �޼���
	void OnTeammateButtonClick(Teammate clickedTeammate)
    {
        Debug.Log(clickedTeammate.teammateName + "�� ��ư�� Ŭ���Ǿ����ϴ�.");
        // Ŭ�� �� �߰� ���� (��: ��ų ���, ���� ��)
        StartBattleWithTeammate(clickedTeammate);
    }

    // ����: ��Ʋ ���� ����
    void StartBattleWithTeammate(Teammate teammate)
    {
        Debug.Log(teammate.teammateName + "�� ��Ʋ�� �����մϴ�.");
    }
}
