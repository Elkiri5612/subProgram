using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teammate : MonoBehaviour
{
    public int maxHP; // �̰͵� ������ ����
    public int standGauge; // �����߻�
    public double defensePercentTeammate = 10.0f; // ������ 10%�� �ʱ�ȭ

    // �� ���Ằ �̸� ����...
    public string teammateName;

    // ��ų ���� ����Ʈ ����
    public List<Skill> skills = new List<Skill>();

    public bool IsInMyTeam = false;
    private TeammateManager teammateManager;


    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("�ϴ��浹��...");
        Player player = other.GetComponent<Player>();

        if (player != null) {
            Debug.Log(teammateName);
            if (this.gameObject.activeSelf != false) {
                IsInMyTeam = true;
                teammateManager.AddTeammate(this);
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        teammateManager = FindObjectOfType<TeammateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
