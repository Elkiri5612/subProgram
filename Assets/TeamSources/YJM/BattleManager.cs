using System.Collections;
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
            //DontDestroyOnLoad(gameObject); // �� ��ȯ �� BattleManager�� ����
        }
        else
        {
            Destroy(gameObject); // �̹� �����ϸ� ���ο� �ν��Ͻ��� ����
        }
    }

    // ����: ���� �߰� �޼���
    public void AddTeammate(Teammate teammate)
    {
        if (!battleTeammates.Contains(teammate))
        {
            battleTeammates.Add(teammate);
            Debug.Log(teammate.teammateName + "�� ���� �߰��Ǿ����ϴ�.");
        }
    }

    // ����: ���� �߰� ����
    void Start()
    {
        // �ӽ� ���� ��ü �߰� (�׽�Ʈ��)
        AddTestTeammates();

        // ��Ʋ�� �����ϴ� ����� �α� ���
        foreach (Teammate teammate in battleTeammates)
        {
            Debug.Log("��Ʋ�� ������ ����: " + teammate.teammateName);
        }
    }

    // �ӽ� ���� �߰� �޼���
    void AddTestTeammates()
    {
        Teammate newTeammate1 = new Teammate();
        newTeammate1.teammateName = "Teammate 1";
        AddTeammate(newTeammate1);

        Teammate newTeammate2 = new Teammate();
        newTeammate2.teammateName = "Teammate 2";
        AddTeammate(newTeammate2);
    }
}
