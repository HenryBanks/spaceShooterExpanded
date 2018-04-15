using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public static DialogueManager instance;

	Dialogue currentDialogue;
	uint index;

	Text dialogueText;
	Image portrait;
	CanvasGroup dialoguePanel;

	[SerializeField]
	Dialogue[] allDialogues;

	[SerializeField]
	Image blackScreen;

	// Use this for initialization
	void Awake () {
		instance = this;
		dialogueText = GetComponentInChildren<Text> ();
		portrait = transform.Find("Image").GetComponent<Image> ();
		dialoguePanel = GetComponent<CanvasGroup> ();


	}

	void Start(){
		CloseDialogue ();

		//Time.timeScale = 0.0f;
		StartCoroutine (FadeIn ());
		LoadDialogue (DialogueName.Intro);
	}

	IEnumerator FadeIn(){
		Debug.Log ("FADE IN");
		for (float alpha = 1.0f; alpha >= 0.0f; alpha -= Time.unscaledDeltaTime) {
			//Debug.Log (alpha);
			blackScreen.color = new Color (0, 0, 0, alpha);
			yield return null;
		}
	}

	void SetText(DialogueLine currentLine){
		portrait.sprite = currentDialogue.Characters[currentLine.Character];
		dialogueText.text = currentLine.Line;
	}

	public void LoadDialogue(DialogueName newDialogue){
		
		currentDialogue = allDialogues[(int)newDialogue];

		index = 0;
		SetText (currentDialogue.Lines [index]);

		OpenDialogue ();
	}

	void CloseDialogue(){
		Time.timeScale = 1.0f;
		dialoguePanel.alpha = 0.0f;
		dialoguePanel.interactable = false;
	}

	void OpenDialogue(){
		Time.timeScale = 0.0f;
		dialoguePanel.alpha = 1.0f;
		dialoguePanel.interactable = true;
	}

	void NextLine(){
		index++;
		if (index >= currentDialogue.Lines.Length) {
			CloseDialogue ();
		} else {
			SetText (currentDialogue.Lines [index]);
		}
	}

	void Update(){
		if (dialoguePanel.interactable) {
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {
				NextLine ();
			}
		}
	}

}

public enum DialogueName{
	Intro,
	End
}