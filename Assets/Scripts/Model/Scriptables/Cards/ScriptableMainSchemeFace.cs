using UnityEngine;

[CreateAssetMenu(fileName = "Main Scheme Face", menuName = "Cards/Main Scheme/Face")]
public class ScriptableMainSchemeFace : ScriptableObject
{
	[Header("Face Attributes")]
	[SerializeField] protected string Id;
	[SerializeField] protected string Name;
	[SerializeField] protected Sprite Image;
	[SerializeField] protected int Stage;
	[SerializeField] protected ScriptableCommand SetupAbility;

	public IEntity Create(IEntity entity)
	{
		IEntity face = new Entity(Id, entity.Owner);
		face.AddComponent<INameComponentProxy>(new NameComponentProxy(Name, Image));
		face.AddComponent<IStageComponentProxy>(new StageComponentProxy(Stage));
		if (null != SetupAbility) face.AddComponent<ISetupComponentProxy>(new SetupComponentProxy(SetupAbility.Create(entity)));

		return (face);
	}
}
