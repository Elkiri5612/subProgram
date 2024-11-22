using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public Monster currentMonster; // ���� �����ϴ� ����

    // Start is called before the first frame update
    void Start()
    {
        GameObject MonsterObject = new GameObject("��Լ�");
        Monster monster = MonsterObject.AddComponent<Monster>();

        monster.InitializeMonster("��Լ�");

        currentMonster = monster;
        Debug.Log($"��Ʋ�� ������ ����: {currentMonster.MonsterName}");
        Debug.Log($"HP: {currentMonster.maxHP}, ���ݷ�: {currentMonster.attackPower}, ��ų ����: {currentMonster.skills.Count}");
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
