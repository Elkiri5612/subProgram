using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }

    public List<Teammate> battleTeammates = new List<Teammate>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject); // �ʿ� �� Ȱ��ȭ
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // TeammateManager���� ������ ������ �ʱ�ȭ
        InitializeBattleTeammates();

        // ����� ���
        foreach (Teammate teammate in battleTeammates)
        {
            Debug.Log("��Ʋ�� ������ ����: " + teammate.teammateName);
        }
    }

    private void InitializeBattleTeammates()
    {
        TeammateManager teammateManager = FindObjectOfType<TeammateManager>();
        if (teammateManager != null)
        {
            // TeammateManager���� Ȱ��ȭ�� ���� ��� ��������
            battleTeammates = new List<Teammate>(teammateManager.teammates);
        }
        else
        {
            Debug.LogError("TeammateManager�� ã�� �� �����ϴ�!");
        }
    }
}
