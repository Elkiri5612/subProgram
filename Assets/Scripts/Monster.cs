using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    public int maxHP;
    public int speed;
    public int standGauge = 50;
    public int attackPower;
    public int currentHP;
    public double defensePercent;
    public string MonsterName;
    public List<Skill> skills = new List<Skill>();
    public bool skillsInitialized = false;
    public bool stun = false; //���� ����
    public bool usedSkill = false; //��ų ��� ����
    public int monsterCategory;

	public double RandomDamage(int startPercent, int endPercent, int baseAttackPower) {
		System.Random rand = new System.Random();
		double randPercent = rand.Next(startPercent, endPercent) / 100.0;
		return randPercent * baseAttackPower;
	} // ���� ������ ������ �����ص��� ���� ����

    // monsterCategory ����:
    // ô�ĺ� �� ��� -1, ô�ĺ�(�߰�����) 0, ô�ĺ� �� ��� 1, ��Լ� 2, �������� 3(����)

	private static readonly Dictionary<string, MonsterData> MonsterDataDict = new Dictionary<string, MonsterData>
    {
        
        {
            "�ܰ��� �ϱ�����", 
            new MonsterData(420, 40, 90, 10.0, -1, new List<Skill>
            {
                new Skill("�����ϰ� �ֵθ���", 120, 0.0, 0,15),
                new Skill("������ ��ħ", 0, 0.0, 0,25)

            }) // monsterCategory = 0
        },
        {
            "�ܰ��� ô�ĺ�",
            new MonsterData(800, 100, 150, 15.0, 0, new List<Skill>
            {
                new Skill("������ ����", 80, 0.0, 0,30),
                new Skill("��� ����", 180, 0.0, 0,50),
                new Skill("���ڽ� ����",120,0.0,0,100)
            }) // monsterCategory = 1
        },
        {
            "�ܰ��� ������",
            new MonsterData(1200, 80, 100, 15.0, 1, new List<Skill>
            {
                new Skill("�����", 150, 0.0, 0,30),
                new Skill("���� ����", 0, 0.0, 0,50),
                new Skill("������",170,0.0,0,100)
            }) // monsterCategpry = 0
        },
        {
            "��Լ�",
            new MonsterData(1800, 150, 130, 10.0, 2, new List<Skill>
            {
                new Skill("���� â", 80, 0.0, 0,40),
                new Skill("Ȥ���� �ٶ�", 60, 0.0, 0,60),
                new Skill("���� ����", 120, 0.0, 0,100)
            }) // monsteCategoty = 2
        }

    };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InitializeMonster(string name)
    {
		if (MonsterDataDict.TryGetValue(name, out MonsterData data)) {
			MonsterName = name;
			maxHP = data.MaxHP;
			attackPower = data.AttackPower;
			speed = data.Speed;
			defensePercent = data.DefensePercent;
			monsterCategory = data.MonsterCategory;
			skills = new List<Skill>(data.Skills);
			skillsInitialized = true;
			stun = false;
			usedSkill = false;
            currentHP = maxHP;
            Debug.Log($"{MonsterName} �ʱ�ȭ �Ϸ�: HP {maxHP}, ���ݷ� {attackPower}, ī�װ� {monsterCategory}");
		} 
        else {
			Debug.LogError($"MonsterDataDict�� {name} �����Ͱ� �����ϴ�!");
		}
	}

    private class MonsterData
    {
        public int MaxHP { get; }
        public int AttackPower { get; }
        public int Speed { get; }
        public double DefensePercent { get; }
        public int MonsterCategory { get;  }
        public List<Skill> Skills { get; }

        public MonsterData(int maxHP, int attackPower, int speed, double defensePercent, int monsterCategory, List<Skill> skills)
        {
            MaxHP = maxHP;
            AttackPower = attackPower;
            Speed = speed;
            DefensePercent = defensePercent;
            MonsterCategory = monsterCategory;
            Skills = skills;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {


        DontDestroyOnLoad(gameObject);


    }
}
