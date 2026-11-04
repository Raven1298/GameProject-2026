using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] DialogueData dialogue;
    [SerializeField] bool autoStart = false;
    [SerializeField] bool playOnce = false;
    [SerializeField] GameObject promptIcon;

    bool playerInRange;

    bool Consumed => playOnce && dialogue != null && DialogueManager.Seen.Contains(dialogue.name);  // [8]

    void Reset()
    {
        var c = GetComponent<Collider2D>();                                // [9]
        if (c) c.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        playerInRange = true;
        if (autoStart) Begin();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) playerInRange = false;
    }

    void Update()
    {
        if (promptIcon)                                                    // [7]
            promptIcon.SetActive(playerInRange && !autoStart && !Consumed && !DialogueManager.IsActive);
        if (playerInRange && !autoStart && DialogueManager.InteractPressed) Begin();  // [1][2]
    }

    void Begin()
    {
        if (dialogue == null || Consumed || !DialogueManager.CanStart) return;        // [1][3]
        if (DialogueManager.Instance == null)
        { Debug.LogWarning("No DialogueManager in scene", this); return; }            // [3]
        if (playOnce) DialogueManager.Seen.Add(dialogue.name);                        // [8]
        DialogueManager.Instance.StartDialogue(dialogue);
    }
}