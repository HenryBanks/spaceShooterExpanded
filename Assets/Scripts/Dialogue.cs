using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName="Data File/Dialogue")]
public class Dialogue : ScriptableObject {

	[SerializeField]
	private Sprite[] characters;
	public Sprite[] Characters{get{return characters;}}

	[SerializeField]
	private DialogueLine[] lines;
	public DialogueLine[] Lines{get{return lines;}}


}

[System.Serializable]
public struct DialogueLine {

	[SerializeField]
	uint character;
	public uint Character{get{return character; }}

	[SerializeField]
	string line;
	public string Line{get{return line; }}

}

