using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Data File/Spawn Group")]
public class SpawnGroup : ScriptableObject {

	[SerializeField]
	private SpawnType groupType;
	public SpawnType GroupType{ get{return groupType; } }

	[SerializeField]
	private Destructible[] destructibles;
	public Destructible[] Destructibles{ get{return destructibles; } }



}

public enum SpawnType{
	Meteor,
	Enemy,
	Missile,
}