using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Cards/Back")]
public class ScriptableBack : ScriptableEntity
{
	[Header("Back Attributes")]
	[SerializeField] protected string Name;
	[SerializeField] protected Sprite Image;

	public override IEntity Create()
	{
		IEntity card = new Entity();
		card.AddComponent<INameComponentProxy>(new NameComponentProxy(Name, Image));
		return (card);
	}
}
