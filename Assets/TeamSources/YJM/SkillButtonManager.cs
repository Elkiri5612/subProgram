using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillButtonManager : MonoBehaviour
{
    public List<Button> skillButtons = new List<Button>(); // �̹� ������ ��ư ����Ʈ
    public BattleManager battleManager;
    public Teammate ActiveTeammate;
    public Monster monster;
    public Skill skill;
    private PriorityQueue actionQueue = new PriorityQueue(); // �켱���� ť

    void Start()
    {
        battleManager = BattleManager.Instance;
        if (battleManager == null)
        {
            Debug.LogError("BattleManager�� �ʱ�ȭ���� �ʾҽ��ϴ�!");
        }

        // ���� �� ��� ��ư ��Ȱ��ȭ
        DisableAllButtons();
    }

    public void DisableAllButtons()
    {
        foreach (var button in skillButtons)
        {
            button.gameObject.SetActive(false); // ��ư ��Ȱ��ȭ
        }
    }

    public void ActivateSkillButtons(Teammate teammate)
    {
        if (Object.ReferenceEquals(teammate, null))
        {
            Debug.LogError("���޵� Teammate�� Unity���� �����Ǿ����ϴ�.");
            DisableAllButtons();
            return;
        }

        ActiveTeammate = teammate;

        Debug.Log($"ActivateSkillButtons ȣ��: �̸� = {ActiveTeammate.teammateName}, ü�� = {ActiveTeammate.maxHP}, ��ų ���� = {ActiveTeammate.skills?.Count ?? 0}");

        if (ActiveTeammate.skills == null || ActiveTeammate.skills.Count == 0)
        {
            Debug.LogWarning($"{ActiveTeammate.teammateName}���� ��ų�� �����ϴ�.");
            DisableAllButtons();
            return;
        }

        for (int i = 0; i < skillButtons.Count; i++)
        {
            if (i < ActiveTeammate.skills.Count)
            {
                Button button = skillButtons[i];
                button.gameObject.SetActive(true);

                TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
                if (buttonText != null)
                {
                    buttonText.text = ActiveTeammate.skills[i].skillName;
                }

                
                int capturedIndex = i; // Ŭ���� ���� ����
                
                button.onClick.RemoveAllListeners();
                button.onClick.AddListener(() => OnSkillButtonClicked(ActiveTeammate,ActiveTeammate.skills[capturedIndex]));

                Debug.Log($"��ư {i + 1} Ȱ��ȭ: {ActiveTeammate.skills[i].skillName}");
            }
            else
            {
                skillButtons[i].gameObject.SetActive(false);
                Debug.Log($"��ư {i + 1} ��Ȱ��ȭ");
            }
        }
    }
    public void OnSkillButtonClicked(Teammate Teammate, Skill skill)
    {
        Debug.Log($"OnSkillButtonClickedȣ��: �̸� = {Teammate.teammateName}, ü�� = {Teammate.maxHP}, ��ų ���� = {Teammate.skills?.Count ?? 0}");
        if (!Teammate.usedSkill)
        {
            if (!Teammate.stun)
            {
                Debug.Log($"��ų '{skill.skillName}' ��ư Ŭ����");
                Debug.Log($"��ų�� ���� : �̸� : {skill.skillName}, ���ݷ� : {skill.attackDamage}, ���� ���� : {skill.defensePercent}, ���� : {skill.buffConst} ");
                /*if (Teammate == null)
                {
                    Debug.LogError("SkillButtonManager���� ���޵� teammate�� null�Դϴ�!");
                }*/

                if (skill == null)
                {
                    Debug.LogError("SkillButtonManager���� ���޵� skill�� null�Դϴ�!");
                }

                if (Teammate.standGauge - skill.usingStandGauge >= 0)
                {
                    Teammate.usedSkill = true;
                    actionQueue.Enqueue(new ActionData(Teammate, skill));
                    DisableAllButtons();
                    CheckAndExecuteQueue();
                }
                else
                {
                    Debug.Log($"{Teammate.teammateName}�� ���ĵ� �������� �����մϴ�!!");
                }
            }
            else
            {
                Debug.Log($"{Teammate.teammateName}�� ���������Դϴ�!");
            }
        }
        else
        {
            Debug.Log($"{Teammate.teammateName}�� �̹� ��ų�� ����߽��ϴ�.");
        }



    }

    public class ActionData //ť�� ��������
    {
        public Teammate teammate;
        public Skill skill;
        public int speed;

        public ActionData(Teammate teammate, Skill skill)
        {
            this.teammate = teammate;
            this.skill = skill;
            this.speed = teammate.speed;
        }
    }

    public class PriorityQueue//�켱���� ť
    {
        private List<ActionData> actions = new List<ActionData>();

        public void Enqueue(ActionData action)
        {
            actions.Add(action);
            actions.Sort((a, b) => b.speed.CompareTo(a.speed)); // ���ǵ尡 ���� ������� ����
        }

        public ActionData Dequeue()
        {
            if (actions.Count == 0) return null;
            var action = actions[0];
            actions.RemoveAt(0);
            return action;
        }

        public int Count => actions.Count;

        public void Clear()
        {
            actions.Clear();
        }
    }

    
    private void CheckAndExecuteQueue()
    {

        // ��� �ൿ�� �ԷµǾ����� Ȯ�� (��: �ൿ ����Ʈ�� Ư�� ũ�⿡ ����)
        if (actionQueue.Count >= battleManager.GetExpectedActionsCount())
        {
            StartCoroutine(ExecuteActions());
        }
    }

    private System.Collections.IEnumerator ExecuteActions()
    {
        while (actionQueue.Count > 0)
        {
            ActionData action = actionQueue.Dequeue();
            Debug.Log($"{action.teammate.teammateName}��(��) {action.skill.skillName}��(��) �����մϴ�.");
            battleManager.ApplySkillDamage(action.teammate, action.skill);

            if ( action.teammate.speed < battleManager.battleMonster.speed && !battleManager.battleMonster.usedSkill)
            {
                
                System.Random rand = new System.Random();
                int randSkill = rand.Next(0, battleManager.battleMonster.skills.Count);
                battleManager.battleMonster.usedSkill = true;
                battleManager.MonsterSkillUse(battleManager.battleMonster, battleManager.battleMonster.skills[randSkill]);
            }
            // �ൿ �� ������ �߰�
            yield return new WaitForSeconds(1.0f);
        }
        

    }
    
}
