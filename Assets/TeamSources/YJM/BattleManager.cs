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
            teammate.standGauge -= skill.usingStandGauge;
            double Damage = RandomDamage(110, 140, 100);
            battleMonster.currentHP -= Mathf.RoundToInt((float)Damage);
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            Debug.Log($"���� {battleMonster.MonsterName}���� {Damage}�� �������� �������ϴ�!");
            Debug.Log($"���� ���� ü��: {battleMonster.currentHP}/{battleMonster.maxHP}");

        }
        if(skill.skillName == "������ ��ġ")
        {
            teammate.standGauge -= skill.usingStandGauge;
            double Damage = RandomDamage(180, 220, 100);
            battleMonster.currentHP -= Mathf.RoundToInt((float)Damage);
            //���� ���� �ʿ� 
            //�� ���� �ڵ� �ʿ�
            battleMonster.stun = true;
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            if (battleMonster.stun)
            {
                Debug.Log($"���� {battleMonster.MonsterName}�� �����߽��ϴ�!");
            }
            Debug.Log($"���� {battleMonster.MonsterName}���� {Damage}�� �������� �������ϴ�!");
            Debug.Log($"���� ���� ü��: {battleMonster.currentHP}/{battleMonster.maxHP}");
        }
        if(skill.skillName == "��Ÿ �÷�Ƽ�� ����")
        {
            teammate.standGauge -= skill.usingStandGauge;
            double Damage = RandomDamage(430, 470, 100);
            battleMonster.currentHP -= Mathf.RoundToInt((float)Damage);
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            Debug.Log($"���� {battleMonster.MonsterName}���� {Damage}�� �������� �������ϴ�!");
            Debug.Log($"���� ���� ü��: {battleMonster.currentHP}/{battleMonster.maxHP}");
        }
        if(skill.skillName == "ȭ����")
        {
            teammate.standGauge -= skill.usingStandGauge;
            double Damage = RandomDamage(90, 120, 120);
            battleMonster.currentHP -= Mathf.RoundToInt((float)Damage);
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            Debug.Log($"���� {battleMonster.MonsterName}���� {Damage}�� �������� �������ϴ�!");
            Debug.Log($"���� ���� ü��: {battleMonster.currentHP}/{battleMonster.maxHP}");
        }
        if (skill.skillName == "�Ҳ��� �ϰ�")
        {
            teammate.standGauge -= skill.usingStandGauge;
            double Damage = RandomDamage(230, 250, 120);
            battleMonster.currentHP -= Mathf.RoundToInt((float)Damage);
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            Debug.Log($"���� {battleMonster.MonsterName}���� {Damage}�� �������� �������ϴ�!");
            Debug.Log($"���� ���� ü��: {battleMonster.currentHP}/{battleMonster.maxHP}");
        }
        if (skill.skillName == "������ �Ҳ�")
        {
            teammate.standGauge -= skill.usingStandGauge;
            double Damage = RandomDamage(490, 510, 120);
            battleMonster.currentHP -= Mathf.RoundToInt((float)Damage);
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            Debug.Log($"���� {battleMonster.MonsterName}���� {Damage}�� �������� �������ϴ�!");
            Debug.Log($"���� ���� ü��: {battleMonster.currentHP}/{battleMonster.maxHP}");
        }
        if (skill.skillName == "������ ����")
        {
            teammate.standGauge -= skill.usingStandGauge;
            teammate.defensePercentTeammate += 20;
            //���� ���� �ʿ�
            //�� ���� �ڵ� �ʿ�
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            Debug.Log($"{teammate.teammateName}��(��) {teammate.defensePercentTeammate}�� ������ �����ϴ�.");
        }
        if (skill.skillName == "������ ����")
        {
            teammate.standGauge -= skill.usingStandGauge;
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
            teammate.standGauge -= skill.usingStandGauge;
            double Damage = RandomDamage(280, 310, 90);
            battleMonster.currentHP -= Mathf.RoundToInt((float)Damage);
            battleMonster.stun = true;
            //���� �ڵ� ���� �ʿ�
            //�� ���� �ڵ� �ʿ�
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            if (battleMonster.stun)
            {
                Debug.Log($"���� {battleMonster.MonsterName}�� �����߽��ϴ�!");
            }
            Debug.Log($"���� {battleMonster.MonsterName}���� {Damage}�� �������� �������ϴ�!");
            Debug.Log($"���� ���� ü��: {battleMonster.currentHP}/{battleMonster.maxHP}");
        }
        if (skill.skillName == "���� ���")
        {
            teammate.standGauge -= skill.usingStandGauge;
            double Damage = RandomDamage(120, 120, 80);
            battleMonster.currentHP -= Mathf.RoundToInt((float)Damage);
            //���� �ڵ� ���� �ʿ�
            //�� ���� �ڵ� �ʿ�

            battleMonster.stun = true;
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            if (battleMonster.stun)
            {
                Debug.Log($"���� {battleMonster.MonsterName}�� �����߽��ϴ�!");
            }
            Debug.Log($"���� {battleMonster.MonsterName}���� {Damage}�� �������� �������ϴ�!");
            Debug.Log($"���� ���� ü��: {battleMonster.currentHP}/{battleMonster.maxHP}");
        }
        if (skill.skillName == "���� ��ȭ")
        {
            teammate.standGauge -= skill.usingStandGauge;
            foreach (Teammate battleteammate in battleTeammates)
            {
                battleteammate.attackPercent *= 1.2;
                battleteammate.defensePercentTeammate += 20;
                Debug.Log($"{battleteammate.teammateName}�� ���ݷ��� {battleteammate.attackPercent}�Դϴ�.");
                Debug.Log($"{battleteammate.teammateName}�� ������ {battleteammate.defensePercentTeammate}�Դϴ�.");
            }
            //�� ���� �ڵ� �ʿ�
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
        }
        if (skill.skillName == "õ���� ����")
        {
            teammate.standGauge -= skill.usingStandGauge;
            double Damage = RandomDamage(350, 400, 80);
            battleMonster.currentHP -= Mathf.RoundToInt((float)Damage);
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            Debug.Log($"���� {battleMonster.MonsterName}���� {Damage}�� �������� �������ϴ�!");
            Debug.Log($"���� ���� ü��: {battleMonster.currentHP}/{battleMonster.maxHP}");
        }
        if (skill.skillName == "ġ���� �ٶ�")
        {
            teammate.standGauge -= skill.usingStandGauge;
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            foreach (Teammate battleteammate in battleTeammates)
            {
                battleteammate.currentHP += 40;
                Debug.Log($"{battleteammate.teammateName}�� ü���� {battleteammate.currentHP}�Դϴ�.");
            }
            

        }

        if (skill.skillName == "�ٶ��� �⵵")
        {
            //�� ���� �ڵ� �ʿ�
            teammate.standGauge -= skill.usingStandGauge;
            double Damage = RandomDamage(100, 120, 80);
            battleMonster.currentHP -= Mathf.RoundToInt((float)Damage);
            double decrease = battleMonster.attackPower * 0.2;
            battleMonster.attackPower -= Mathf.RoundToInt((float)decrease);
            Debug.Log($"{teammate.teammateName}�� ���� ���ĵ�������� {teammate.standGauge}�Դϴ�.");
            Debug.Log($"{teammate.teammateName}��(��) {skill.skillName}��(��) ����߽��ϴ�!");
            Debug.Log($"���� {battleMonster.MonsterName}���� {Damage}�� �������� �������ϴ�!");
            Debug.Log($"���� {battleMonster.MonsterName}�� ���� ���ݷ��� {battleMonster.attackPower}�Դϴ�.");
            Debug.Log($"���� ���� ü��: {battleMonster.currentHP}/{battleMonster.maxHP}");
        }

        if (skill.skillName == "ȸ���� ��ǳ")
        {
            //�� ���� �ڵ� �ʿ�
            teammate.standGauge -= skill.usingStandGauge;
            foreach (Teammate battleteammate in battleTeammates)
            {
                double health = teammate.maxHP * 0.35;
                teammate.currentHP += Mathf.RoundToInt((float)health);
                teammate.defensePercentTeammate += 15;
                Debug.Log($"{battleteammate.teammateName}�� ������ {battleteammate.defensePercentTeammate}�Դϴ�.");
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
