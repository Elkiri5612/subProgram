using System.Collections.Generic;
using UnityEngine;

public class Teammate : MonoBehaviour
{
    public int maxHP;
    public int speed;
    public int standGauge = 50;
    public int attackPower;
    public double defensePercentTeammate;
    public string teammateName;
    public List<Skill> skills = new List<Skill>();
    public bool skillsInitialized = false;
    public bool IsInMyTeam = false;

    private static readonly Dictionary<string, TeammateData> teammateDataDict = new Dictionary<string, TeammateData>
    {
        {
            "�����",
            new TeammateData(220, 100, 200, 10.0, new List<Skill>
            {
                new Skill("�������� �̵�", 110, 0.0, 0),
                new Skill("������ ��ġ", 180, 0.0, 0),
                new Skill("��Ÿ �÷�Ƽ�� ����", 430, 0.0, 0)
            })
        },
        {
            "������",
            new TeammateData(190, 120, 120, 10.0, new List<Skill>
            {
                new Skill("ȭ����", 90, 0.0, 0),
                new Skill("�Ҳ��� �ϰ�", 230, 0.0, 0),
                new Skill("������ �Ҳ�", 490, 0.0, 0)
            })
        },
        {
            "������",
            new TeammateData(270, 90, 90, 10.0, new List<Skill>
            {
                new Skill("������ ����", 0, 20.0, 0),
                new Skill("������ ����", 0, 0.0, 0),
                new Skill("������ �г�", 280, 0.0, 0)
            })
        },
        {
            "�����",
            new TeammateData(200, 80, 180, 10.0, new List<Skill>
            {
                new Skill("���� ���", 120, 0.0, 0),
                new Skill("���� ��ȭ", 0, 0.0, 0),
                new Skill("õ���� ����", 350, 0.0, 0)
            })
        },
        {
            "�ֵ��� & ����",
            new TeammateData(180, 80, 120, 10.0, new List<Skill>
            {
                new Skill("ġ���� �ٶ�", 0, 0.0, 0),
                new Skill("�ٶ��� �⵵", 100, 0.0, 0),
                new Skill("ȸ���� ��ǳ", 0, 0.0, 0)
            })
        }
    };

    void Start()
    {
        InitializeTeammate(teammateName);
    }

    public void InitializeTeammate(string name)
    {
        if (teammateDataDict.TryGetValue(name, out TeammateData data))
        {
            teammateName = name;
            maxHP = data.MaxHP;
            attackPower = data.AttackPower;
            speed = data.Speed;
            defensePercentTeammate = data.DefensePercent;
            skills = new List<Skill>(data.Skills);
            skillsInitialized = true;
        }
        else
        {
            Debug.LogError($"Teammate data for {name} not found!");
        }
    }

    private class TeammateData
    {
        public int MaxHP { get; }
        public int AttackPower { get; }
        public int Speed { get; }
        public double DefensePercent { get; }
        public List<Skill> Skills { get; }

        public TeammateData(int maxHP, int attackPower, int speed, double defensePercent, List<Skill> skills)
        {
            MaxHP = maxHP;
            AttackPower = attackPower;
            Speed = speed;
            DefensePercent = defensePercent;
            Skills = skills;
        }
    }
}
