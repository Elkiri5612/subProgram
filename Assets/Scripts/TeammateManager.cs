using System.Collections.Generic;
using UnityEngine;

public class TeammateManager : MonoBehaviour
{
    public List<Teammate> teammates = new List<Teammate>(); // ���� ���� �ִ� ���� ���

    void Start()
    {
        // ���ο� Teammate ����
        GameObject teammateObject = new GameObject("kimsubin");
        Teammate kimsubin = teammateObject.AddComponent<Teammate>();

        // Teammate �ʱ�ȭ
        kimsubin.InitializeTeammate("kimsubin");

        // �� ��Ͽ� �߰�
        AddTeammate(kimsubin);

        Debug.Log($"�̸�: {kimsubin.teammateName}, ü��: {kimsubin.maxHP}, ���ݷ�: {kimsubin.attackPower}, ��ų: {kimsubin.skills}");

        Debug.Log("Teammates in TeammateManager:");
        foreach (var teammate in teammates)
        {
            Debug.Log(teammate.teammateName);
        }

    }
    void Awake()
    {


            DontDestroyOnLoad(gameObject);
      

    }

    public void AddTeammate(Teammate teammate)
    {
        // �̹� ���� �߰��� �������� Ȯ��
        if (teammates.Exists(t => t.teammateName == teammate.teammateName))
        {
            Debug.LogWarning($"{teammate.teammateName}��(��) �̹� ���� �߰��Ǿ� �ֽ��ϴ�.");
            return;
        }

        // �� ��Ͽ� �߰�
        teammates.Add(teammate);

        Debug.Log($"{teammate.teammateName}��(��) ���� �߰��Ǿ����ϴ�.");
    }
}
