using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager Instance { get; private set; }
    public TeammateManager teammateManager; // Unity Editor���� ���� ����
    public MonsterManager monsterManager; // Unity Editor���� ���� ����
    public List<Teammate> battleTeammates = new List<Teammate>();
    public Monster battleMonster; // ��Ʋ�� �����ϴ� ����

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

        if (monsterManager == null)
        {
            monsterManager = FindObjectOfType<MonsterManager>();
        }

        if (teammateManager == null)
        {
            Debug.LogError("TeammateManager�� ã�� �� �����ϴ�! ���� TeammateManager�� �߰��ߴ��� Ȯ���ϼ���.");
            return;
        }

        if (monsterManager == null)
        {
            Debug.LogError("MonsterManager�� ã�� �� �����ϴ�! ���� MonsterManager�� �߰��ߴ��� Ȯ���ϼ���.");
            return;
        }
        // Teammates�� Monster �ʱ�ȭ
        InitializeBattleTeammates();
        InitializeBattleMonster();

    }





    private void InitializeBattleTeammates()
    {
        battleTeammates = new List<Teammate>(teammateManager.teammates);
        Debug.Log($"Teammates initialized: {battleTeammates.Count}��");
        foreach (var teammate in battleTeammates)
        {
            Debug.Log($"����: {teammate.teammateName}, HP: {teammate.maxHP}, ���ݷ�: {teammate.attackPower}");
        }
    }

    private void InitializeBattleMonster()
    {
        if (monsterManager == null)
        {
            Debug.LogError("monsterManager�� null�Դϴ�!");
            return;
        }

        if (monsterManager.currentMonster == null)
        {
            Debug.LogError("monsterManager�� currentMonster�� null�Դϴ�!");
            return;
        }

        Monster battleMonster = monsterManager.currentMonster;

        if (battleMonster != null)
        {
            Debug.Log($"��Ʋ�� ������ ����: {battleMonster.MonsterName}");
            Debug.Log($"HP: {battleMonster.maxHP}, ���ݷ�: {battleMonster.attackPower}, ��ų ����: {battleMonster.skills.Count}");
        }
        else
        {
            Debug.LogWarning("���� ��Ʋ�� ����� ���Ͱ� �����ϴ�!");
        }
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
    private void PrintBattleMonster()
    {


        Debug.Log($"��Ʋ�� ������ ����: {battleMonster.MonsterName}");

    }

    void Update()
    {
        
    }
}
