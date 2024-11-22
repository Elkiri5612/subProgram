using System.Collections.Generic;
using UnityEngine;

public class TeammateManager : MonoBehaviour
{
    public List<Teammate> teammates = new List<Teammate>(); // ���� ���� �ִ� ���� ���

    void Start()
    {

        // ���ο� Teammate ����
        GameObject teammateObject = new GameObject("�����");
        Teammate Teammate = teammateObject.AddComponent<Teammate>();

        // Teammate �ʱ�ȭ
        Teammate.InitializeTeammate("�����");


        // �� ��Ͽ� �߰�
        AddTeammate(Teammate);

        teammateObject = new GameObject("������");
        Teammate = teammateObject.AddComponent<Teammate>();
        Teammate.InitializeTeammate("������");
        AddTeammate(Teammate);

        teammateObject = new GameObject("�����");
        Teammate = teammateObject.AddComponent<Teammate>();
        Teammate.InitializeTeammate("�����");
        AddTeammate(Teammate);
    }

     void Update()
     {
            

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
    

