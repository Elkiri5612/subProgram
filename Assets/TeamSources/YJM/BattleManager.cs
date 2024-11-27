using System.Collections.Generic;
using UnityEngine;
using System;

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
        PrintBattleTeammates();


    }


    public void ApplySkillDamage(Teammate teammate, Skill skill)
    {
        if (battleMonster == null)
        {
            Debug.LogWarning("battleMonster�� null�Դϴ�. InitializeBattleMonster()�� �ٽ� ȣ���մϴ�.");
            InitializeBattleMonster();

            if (battleMonster == null)
            {
                Debug.LogError("InitializeBattleMonster ȣ�� �Ŀ��� battleMonster�� null�Դϴ�!");
                return;
            }
        }

        /*if (teammate == null)
        {
            Debug.LogError("Teammate null�Դϴ�!");
            return;
        }*/
        if (skill == null)
        {
            Debug.LogError("Skill�� null�Դϴ�!");
            return;
        }
        if(skill.skillName == "�������� �̵�")
        {
            teammate.standGauge -= 20;
            double Damage = RandomDamage(110, 140, 100);
            battleMonster.currentHP -= Mathf.RoundToInt((float)Damage);
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            Debug.Log($"���� {battleMonster.MonsterName}���� {Damage}�� �������� �������ϴ�!");
            Debug.Log($"���� ���� ü��: {battleMonster.currentHP}/{battleMonster.maxHP}");

        }
        if(skill.skillName == "������ ��ġ")
        {
            teammate.standGauge -= 35;
            double Damage = RandomDamage(180, 220, 100);
            battleMonster.currentHP -= Mathf.RoundToInt((float)Damage);
            //���� ���� �ʿ� 
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            Debug.Log($"���� {battleMonster.MonsterName}���� {Damage}�� �������� �������ϴ�!");
            Debug.Log($"���� ���� ü��: {battleMonster.currentHP}/{battleMonster.maxHP}");
        }
        if(skill.skillName == "��Ÿ �÷�Ƽ�� ����")
        {
            teammate.standGauge -= 100;
            double Damage = RandomDamage(430, 470, 100);
            battleMonster.currentHP -= Mathf.RoundToInt((float)Damage);
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            Debug.Log($"���� {battleMonster.MonsterName}���� {Damage}�� �������� �������ϴ�!");
            Debug.Log($"���� ���� ü��: {battleMonster.currentHP}/{battleMonster.maxHP}");
        }
        if(skill.skillName == "ȭ����")
        {
            teammate.standGauge -= 15;
            double Damage = RandomDamage(90, 120, 120);
            battleMonster.currentHP -= Mathf.RoundToInt((float)Damage);
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            Debug.Log($"���� {battleMonster.MonsterName}���� {Damage}�� �������� �������ϴ�!");
            Debug.Log($"���� ���� ü��: {battleMonster.currentHP}/{battleMonster.maxHP}");
        }
        if (skill.skillName == "�Ҳ��� �ϰ�")
        {
            teammate.standGauge -= 30;
            double Damage = RandomDamage(230, 250, 120);
            battleMonster.currentHP -= Mathf.RoundToInt((float)Damage);
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            Debug.Log($"���� {battleMonster.MonsterName}���� {Damage}�� �������� �������ϴ�!");
            Debug.Log($"���� ���� ü��: {battleMonster.currentHP}/{battleMonster.maxHP}");
        }
        if (skill.skillName == "������ �Ҳ�")
        {
            teammate.standGauge -= 100;
            double Damage = RandomDamage(490, 510, 120);
            battleMonster.currentHP -= Mathf.RoundToInt((float)Damage);
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            Debug.Log($"���� {battleMonster.MonsterName}���� {Damage}�� �������� �������ϴ�!");
            Debug.Log($"���� ���� ü��: {battleMonster.currentHP}/{battleMonster.maxHP}");
        }
        if (skill.skillName == "������ ����")
        {
            teammate.standGauge -= 10;
            teammate.defensePercentTeammate += 20;
            //���� ���� �ʿ�
            //�� ���� �ڵ� �ʿ�
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
        }
        if (skill.skillName == "������ ����")
        {
            teammate.standGauge -= 25;
            double health = teammate.maxHP * 0.15;
            teammate.currentHP += Mathf.RoundToInt((float)health);
            teammate.defensePercentTeammate += 20;
            //�� ���� �ڵ� �ʿ�
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            Debug.Log($"{teammate.teammateName}��(��) {health}��ŭ ȸ���߽��ϴ�!");
            Debug.Log($"{teammate.teammateName}��(��) {teammate.defensePercentTeammate}�� ������ �����ϴ�.");
        }
        if (skill.skillName == "������ �г�")
        {
            teammate.standGauge -= 100;
            double Damage = RandomDamage(280, 310, 90);
            battleMonster.currentHP -= Mathf.RoundToInt((float)Damage);
            //���� �ڵ� ���� �ʿ�
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            Debug.Log($"���� {battleMonster.MonsterName}���� {Damage}�� �������� �������ϴ�!");
            Debug.Log($"���� ���� ü��: {battleMonster.currentHP}/{battleMonster.maxHP}");
        }
        if (skill.skillName == "���� ���")
        {
            teammate.standGauge -= 15;
            double Damage = RandomDamage(120, 120, 80);
            battleMonster.currentHP -= Mathf.RoundToInt((float)Damage);
            //���� �ڵ� ���� �ʿ�
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            Debug.Log($"���� {battleMonster.MonsterName}���� {Damage}�� �������� �������ϴ�!");
            Debug.Log($"���� ���� ü��: {battleMonster.currentHP}/{battleMonster.maxHP}");
        }
        if (skill.skillName == "���� ��ȭ")
        {
            teammate.standGauge -= 20;
            foreach (Teammate battleteammate in battleTeammates)
            {
                battleteammate.attackPercent *= 1.2;
                battleteammate.defensePercentTeammate += 20;
            }
            //�� ���� �ڵ� �ʿ�
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
        }
        if (skill.skillName == "õ���� ����")
        {
            teammate.standGauge -= 100;
            double Damage = RandomDamage(350, 400, 80);
            battleMonster.currentHP -= Mathf.RoundToInt((float)Damage);
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            Debug.Log($"���� {battleMonster.MonsterName}���� {Damage}�� �������� �������ϴ�!");
            Debug.Log($"���� ���� ü��: {battleMonster.currentHP}/{battleMonster.maxHP}");
        }
        if (skill.skillName == "ġ���� �ٶ�")
        {
            teammate.standGauge -= 20;
            foreach (Teammate battleteammate in battleTeammates)
            {
                battleteammate.currentHP += 40;
            }
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");

        }

        if (skill.skillName == "�ٶ��� �⵵")
        {
            teammate.standGauge -= 40;
            double Damage = RandomDamage(100, 120, 80);
            battleMonster.currentHP -= Mathf.RoundToInt((float)Damage);
            double decrease = battleMonster.attackPower * 0.2;
            battleMonster.attackPower -= Mathf.RoundToInt((float)decrease);
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            Debug.Log($"���� {battleMonster.MonsterName}���� {Damage}�� �������� �������ϴ�!");
            Debug.Log($"���� ���� ü��: {battleMonster.currentHP}/{battleMonster.maxHP}");
        }

        if (skill.skillName == "ȸ���� ��ǳ")
        {
            teammate.standGauge -= 100;
            foreach (Teammate battleteammate in battleTeammates)
            {
                double health = teammate.maxHP * 0.35;
                teammate.currentHP += Mathf.RoundToInt((float)health);
                teammate.defensePercentTeammate += 15;
            }
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");

        }


        // ��ų ������ ���
        /*double damage = (skill.attackDamage * teammate.attackPercent);
        battleMonster.currentHP -= Mathf.RoundToInt((float)damage);

        Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
        Debug.Log($"���� {battleMonster.MonsterName}���� {damage}�� �������� �������ϴ�!");
        Debug.Log($"���� ���� ü��: {battleMonster.currentHP}/{battleMonster.maxHP}");
        if(battleMonster.currentHP <= 0)
        {
            Debug.Log($"{battleMonster.MonsterName}�� �׾����ϴ�.");
        }*/
    }



    private void InitializeBattleTeammates()
    {
        battleTeammates = new List<Teammate>(teammateManager.teammates);
        Debug.Log($"Teammates initialized: {battleTeammates.Count}��");
        foreach (var teammate in battleTeammates)
        {
            Debug.Log($"����: {teammate.teammateName}, HP: {teammate.maxHP}, ���ݷ�: {teammate.attackPercent}");
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

        battleMonster = monsterManager.currentMonster;

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

    public double RandomDamage(int startPercent, int endPercent, int baseAttackPower) {
        System.Random rand = new System.Random();
        double randPercent = rand.Next(startPercent, endPercent) / 100;

        return randPercent * baseAttackPower;

    }

    void Update()
    {
        
    }
}
