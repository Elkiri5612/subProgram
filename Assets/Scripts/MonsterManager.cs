using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager Instance;
    public Monster currentMonster; // ���� �����ϴ� ����

    // Start is called before the first frame update
    void Start()
    {
        /*
        GameObject MonsterObject = new GameObject("�ܰ��� ������");
        Monster monster = MonsterObject.AddComponent<Monster>();

        monster.InitializeMonster("�ܰ��� ������");
        */

        // currentMonster = monster;
        Debug.Log($"��Ʋ�� ������ ����: {currentMonster.MonsterName}");
        Debug.Log($"HP: {currentMonster.maxHP}, ���ݷ�: {currentMonster.attackPower}, ��ų ����: {currentMonster.skills.Count}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void Awake() {
		if (Instance == null) {
			Instance = this;
			DontDestroyOnLoad(gameObject); // �� ��ȯ �� �ı����� ����
		} else {
			Destroy(gameObject); // �ߺ��� �Ŵ����� �������� �ʵ��� ����
		}
	}

	public void SetCurrentMonster(Monster monster) {
		if (monster != null) {
			currentMonster = monster; // ���� ���� ����
			currentMonster.InitializeMonster(currentMonster.MonsterName); // MonsterName���� ������ �ʱ�ȭ
			Debug.Log($"MonsterManager�� ������ ����: {currentMonster.MonsterName}");
		} else {
			Debug.LogError("���޵� Monster ��ü�� null�Դϴ�.");
		}
	}
}
