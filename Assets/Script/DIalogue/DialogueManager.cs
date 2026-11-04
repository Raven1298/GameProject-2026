using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }
    public static bool IsActive { get; private set; }
    public static readonly HashSet<string> Seen = new HashSet<string>();   // [8]
    public static event System.Action OnDialogueStart, OnDialogueEnd;

    static int lastChangeFrame = -1;                                       // [1]
    public static bool CanStart => !IsActive && Time.frameCount != lastChangeFrame;
    public static bool InteractPressed => Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame;     // [2]

    [SerializeField] GameObject panel;
    [SerializeField] TMP_Text speakerText, bodyText;
    [SerializeField] Image portraitImage;
    [SerializeField] float charsPerSecond = 40f;

    DialogueData current;
    int index;
    Coroutine typing;
    bool lineFinished;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void ResetStatics()                                             // [5]
    { Seen.Clear(); IsActive = false; lastChangeFrame = -1; OnDialogueStart = null; OnDialogueEnd = null; }

    void Awake() { Instance = this; panel.SetActive(false); }

    void OnDestroy()                                                       // [5]
    { if (Instance == this) { Instance = null; IsActive = false; } }

    public void StartDialogue(DialogueData data)
    {
        if (IsActive || data == null || data.lines == null || data.lines.Length == 0) return;  // [3]
        current = data; index = 0; IsActive = true;
        lastChangeFrame = Time.frameCount;                                 // [1]
        panel.SetActive(true);
        OnDialogueStart?.Invoke();
        ShowLine();
    }

    void Update()
    {
        if (!IsActive || Time.frameCount == lastChangeFrame || !InteractPressed) return;  // [1][2]
        if (!lineFinished)
        {
            StopCoroutine(typing);
            bodyText.maxVisibleCharacters = 99999;                         // [6]
            lineFinished = true;
        }
        else Next();
    }

    void ShowLine()
    {
        var line = current.lines[index];
        speakerText.text = line.speaker;
        if (portraitImage)                                                 // [3]
        {
            portraitImage.sprite = line.portrait;
            portraitImage.enabled = line.portrait != null;
        }
        typing = StartCoroutine(Type(line.text));
    }

    IEnumerator Type(string text)                                          // [6]
    {
        lineFinished = false;
        bodyText.text = text;
        bodyText.maxVisibleCharacters = 0;
        bodyText.ForceMeshUpdate();
        int total = bodyText.textInfo.characterCount;
        float shown = 0f;
        while (bodyText.maxVisibleCharacters < total)
        {
            shown += charsPerSecond * Time.unscaledDeltaTime;
            bodyText.maxVisibleCharacters = Mathf.Min(total, (int)shown);
            yield return null;
        }
        lineFinished = true;
    }

    void Next()
    {
        index++;
        if (index >= current.lines.Length) End();
        else ShowLine();
    }

    void End()
    {
        panel.SetActive(false);
        IsActive = false;
        lastChangeFrame = Time.frameCount;                                 // [1]
        OnDialogueEnd?.Invoke();
    }
}