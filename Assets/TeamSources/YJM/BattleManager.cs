using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }
    public TeammateManager teammateManager; // Unity Editor���� ���� ����
    public List<Teammate> battleTeammates = new List<Teammate>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �̱��� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // TeammateManager�� ������� �ʾҴٸ� FindObjectOfType�� ã��
        if (teammateManager == null)
        {
            teammateManager = FindObjectOfType<TeammateManager>();
        }

        if (teammateManager == null)
        {
            Debug.LogError("TeammateManager�� ã�� �� �����ϴ�! ���� TeammateManager�� �߰��ߴ��� Ȯ���ϼ���.");
            return;
        }

        // TeammateManager �ʱ�ȭ�� �Ϸ�� ������ ��ٸ�
        StartCoroutine(InitializeBattleTeammatesAfterManagerReady());
    }

    private System.Collections.IEnumerator InitializeBattleTeammatesAfterManagerReady()
    {
        // TeammateManager�� �ʱ�ȭ�� ������ ��ٸ�
        while (teammateManager.teammates.Count == 0)
        {
            Debug.Log("TeammateManager �ʱ�ȭ ��� ��...");
            yield return null; // ���� �����ӱ��� ���
        }

        // Teammates �����͸� BattleTeammates�� ����
        InitializeBattleTeammates();
        PrintBattleTeammates();

        Debug.Log("BattleTeammates in BattleManager:");
        foreach (var teammate in battleTeammates)
        {
            Debug.Log(teammate.teammateName);
        }
    }

    private void InitializeBattleTeammates()
    {
        battleTeammates = new List<Teammate>(teammateManager.teammates);
        Debug.Log($"�̸�: {battleTeammates[0].teammateName}, ü��: {battleTeammates[0].maxHP}, ���ݷ�: {battleTeammates[0].attackPower}, ��ų: {battleTeammates[0].skills}");
        Debug.Log("BattleTeammates�� �ʱ�ȭ�Ǿ����ϴ�.");
    }

    private void PrintBattleTeammates()
    {
        if (battleTeammates.Count == 0)
        {
            Debug.LogWarning("��Ʋ�� ������ ���ᰡ �����ϴ�!");
            return;
        }

        foreach (Teammate teammate in battleTeammates)
        {
            Debug.Log($"��Ʋ�� ������ ����: {teammate.teammateName}");
        }
    }
}
