using UnityEngine;

[CreateAssetMenu(fileName = "Player Value", menuName = "Cards/Player Value")]
public class ScriptablePlayerValue : ScriptableValue
{
	public override int GetValue() => Value * (ServiceLocator.Get<IPlayerService>().Count() - 1);
}
