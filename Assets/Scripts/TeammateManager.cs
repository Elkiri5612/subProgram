using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeammateManager : MonoBehaviour
{
    public static TeammateManager Instance { get; private set; }
    public List<Teammate> teammates = new List<Teammate>();



    public void AddTeammate(Teammate teammate)
    {
        if (!teammates.Contains(teammate))
        {
            teammates.Add(teammate);
            Debug.Log(teammate.teammateName + "��(��) ���� �߰��Ǿ����ϴ�.");
        }
        else
        {
            Debug.Log("���� ���� �߰��Ǿ����� ����");
        }

    }



    // Start is called before the first frame update
    void Start()
    {
        Teammate kimSubin = new GameObject("kimsubin").AddComponent<Teammate>();
        kimSubin.teammateName = "kimsubin";
        AddTeammate(kimSubin);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // �� ��ȯ �ÿ��� ����
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
