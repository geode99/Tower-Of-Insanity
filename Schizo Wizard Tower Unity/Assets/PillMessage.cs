using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PillMessage : MonoBehaviour
{
    // Public inspector fields
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;

    public GameObject contButton;
    public float wordSpeed = 0.02f;

    // How long the dialogue stays visible after pressing E
    public float displayDuration = 3f;

    // Internal state
    private int index;
    private bool playerIsClose;
    private Coroutine typingCoroutine;
    private Coroutine autoCloseCoroutine;

    private void Start()
    {
        // Ensure UI starts hidden and in a consistent state
        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);

        if (contButton != null)
            contButton.SetActive(false);

        if (dialogueText != null)
            dialogueText.text = "";

        index = 0;
    }

    public void zeroText()
    {
        // Stop any running typing coroutine
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

        // Stop any running auto-close coroutine
        if (autoCloseCoroutine != null)
        {
            StopCoroutine(autoCloseCoroutine);
            autoCloseCoroutine = null;
        }

        if (dialogueText != null)
            dialogueText.text = "";

        index = 0;

        if (contButton != null)
            contButton.SetActive(false);

        if (dialoguePanel != null)
            dialoguePanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        if (dialogue == null || dialogue.Length == 0 || index < 0 || index >= dialogue.Length)
        {
            // Nothing to type
            yield break;
        }

        if (dialogueText != null)
            dialogueText.text = "";

        string line = dialogue[index];

        foreach (char letter in line.ToCharArray())
        {
            if (dialogueText != null)
                dialogueText.text += letter;

            yield return new WaitForSeconds(wordSpeed);
        }

        // Typing finished for this line — show continue if there are more lines
        if (contButton != null)
        {
            if (index < dialogue.Length - 1)
                contButton.SetActive(true);
            else
                contButton.SetActive(true); // Could be used as "Close" as well
        }

        typingCoroutine = null;
    }

    // Coroutine to auto-close the dialogue after displayDuration seconds
    IEnumerator AutoCloseRoutine()
    {
        yield return new WaitForSeconds(displayDuration);
        zeroText();
    }

    public void NextLine()
    {
        // Called by the continue button (hook in Inspector)
        if (contButton != null)
            contButton.SetActive(false);

        // Stop any existing typing before moving on
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }

        if (index < dialogue.Length - 1)
        {
            index++;
            if (dialogueText != null)
                dialogueText.text = "";

            typingCoroutine = StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Ensure interaction only works when player is in range
            if (!playerIsClose)
                return;

            // Show panel and start typing the current line
            if (dialoguePanel != null && !dialoguePanel.activeInHierarchy)
                dialoguePanel.SetActive(true);

            if (dialogueText != null)
                dialogueText.text = "";

            if (contButton != null)
                contButton.SetActive(false);

            // Ensure index is within bounds
            if (dialogue == null || dialogue.Length == 0)
                return;

            // Start typing (avoid starting multiple coroutines)
            if (typingCoroutine == null)
                typingCoroutine = StartCoroutine(Typing());

            // Restart auto-close timer: stop previous and start a new one
            if (autoCloseCoroutine != null)
            {
                StopCoroutine(autoCloseCoroutine);
                autoCloseCoroutine = null;
            }
            autoCloseCoroutine = StartCoroutine(AutoCloseRoutine());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only consider player trigger entries
        if (!other.CompareTag("Player"))
            return;

        playerIsClose = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerIsClose = false;
        zeroText();
    }
}




