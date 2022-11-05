using UnityEngine;

[CreateAssetMenu(fileName = "Value", menuName = "Cards/Value")]
public class ScriptableValue : ScriptableObject
{
	[SerializeField] protected int Value;

	public virtual int GetValue() => Value;
}
