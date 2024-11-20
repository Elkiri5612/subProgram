using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teammate : MonoBehaviour
{
    public int maxHP; // �̰͵� ������ ����
    public int speed;
    public int standGauge = 50; // �����߻�
    public int attackPower;
    public double defensePercentTeammate = 10.0f; // ������ 10%�� �ʱ�ȭ
    public bool skillsInitialized = false;
    // �� ���Ằ �̸� ����...
    public string teammateName;

    // ��ų ���� ����Ʈ ����
    public List<Skill> skills = new List<Skill>();

    public bool IsInMyTeam = false;
    private TeammateManager teammateManager;

    /*void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("�ϴ��浹��...");
        Player player = other.GetComponent<Player>();

        if (player != null) {
            Debug.Log(teammateName);
            (this.gameObject.activeSelf != false) {
                IsInMyTeam = true;
                teammateManager.AddTeammate(this);
            } 
        }
    }*/

    // Start is called before the first frame update
    void Start()
    {
        teammateManager = FindObjectOfType<TeammateManager>();
    }

    public void InitializeTeammate(string name)
    {
        

        teammateName = name;
        switch (teammateName)
        {
            case "kimsubin":
                maxHP = 220;
                attackPower = 100;
                speed = 200;
                defensePercentTeammate = 10.0f;
                skills.Add(new Skill("�������� �̵�", 110, 0.0, 0));
                skills.Add(new Skill("������ ��ġ", 180, 0.0, 0));
                skills.Add(new Skill("��Ÿ �÷�Ƽ�� ����", 430, 0.0, 0));
                break;
            case "������":
                maxHP = 190;
                attackPower = 120;
                speed = 120;
                defensePercentTeammate = 10.0f;
                skills.Add(new Skill("ȭ����", 90, 0.0, 0));
                skills.Add(new Skill("�Ҳ��� �ϰ�", 230, 0.0, 0));
                skills.Add(new Skill("������ �Ҳ�", 490, 0.0, 0));
                break;
            case "������":
                maxHP = 270;
                attackPower = 90;
                speed = 90;
                defensePercentTeammate = 10.0f;
                skills.Add(new Skill("������ ����", 0, 20.0, 0));
                skills.Add(new Skill("������ ����", 0, 0.0, 0));
                skills.Add(new Skill("������ �г�", 280, 0.0, 0));
                break;
            case "�����":
                maxHP = 200;
                attackPower = 80;
                speed = 180;
                defensePercentTeammate = 10.0f;
                skills.Add(new Skill("���� ���", 120, 0.0, 0));
                skills.Add(new Skill("���� ��ȭ", 0, 0.0, 0));
                skills.Add(new Skill("õ���� ����", 350, 0.0, 0));
                break;
            case "�ֵ��� & ����":
                maxHP = 180;
                attackPower = 80;
                speed = 120;
                defensePercentTeammate = 10.0f;
                skills.Add(new Skill("ġ���� �ٶ�", 0, 0.0, 0));
                skills.Add(new Skill("�ٶ��� �⵵", 100, 0.0, 0));
                skills.Add(new Skill("ȸ���� ��ǳ", 0, 0.0, 0));
                break;
        }
        skillsInitialized = true;
    }
}


