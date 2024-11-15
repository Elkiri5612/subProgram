using UnityEngine;

public class BoxInteraction : MonoBehaviour
{
    private bool isPlayerNearby = false;
    private Animator animator;
    public GameObject itemUI; // ������ ������ ǥ���ϴ� UI ������Ʈ
    public ParticleSystem openEffect; // ���� ���� ȿ�� (��ƼŬ)
    public AudioClip openSound; // ���� �� �� ����� �Ҹ�
    private AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Debug.Log("�ڽ��� ��ȣ�ۿ��� �غ� �Ǿ����ϴ�!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void Interact()
    {
        Debug.Log("�ڽ��� ��ȣ�ۿ� ��...");

        // ���� ���� �ִϸ��̼� Ʈ����
        if (animator != null)
        {
            animator.SetTrigger("OpenTrigger");
        }

        // ��ƼŬ ȿ�� ���
        if (openEffect != null)
        {
            openEffect.Play();
        }

        // ���� ���� �Ҹ� ���
        if (audioSource != null && openSound != null)
        {
            audioSource.PlayOneShot(openSound);
        }

        // ������ ���� ǥ��
        ShowItemInfo();
    }

    void ShowItemInfo()
    {
        Debug.Log("�������� ȹ���߽��ϴ�!");
        // ������ UI�� Ȱ��ȭ�Ͽ� ������ ������ ǥ��
        if (itemUI != null)
        {
            itemUI.SetActive(true);
        }
    }
}
