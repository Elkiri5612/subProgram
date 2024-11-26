using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill 
{
    public string skillName;
    public double attackDamage;
    public double defensePercent;
    public int buffConst;

    public Skill(string skillName, double attackPercent = 0, double defensePercent = 0.00, int buffConst = 0) {
        // ��ų���� ������ �����ؾ� �ϸ� �⺻ ���ݷ�, ����, ������ 0���� �ʱ�ȭ��
        // �ֳĸ� �ʿ��� ���� �־ �����...
        this.skillName = skillName;
        this.attackDamage = attackPercent;
        this.defensePercent = defensePercent;
        this.buffConst = buffConst;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
