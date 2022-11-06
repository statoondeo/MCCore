using UnityEngine;

[CreateAssetMenu(fileName = "Main Scheme Face", menuName = "Cards/Main Scheme/Face")]
public class ScriptableMainSchemeFace : ScriptableObject
{
	[Header("Face Attributes")]
	[SerializeField] protected string Id;
	[SerializeField] protected string Name;
	[SerializeField] protected Sprite Image;
	[SerializeField] protected string Stage;
	[SerializeField] protected ScriptableCommand SetupAbility;
	[SerializeField] protected ScriptableCommand WhenRevealedAbility;

	[Header("Scheme Attributes")]
	[SerializeField] protected bool IsScheme;
	[SerializeField] protected ScriptableValue Threshold;
	[SerializeField] protected ScriptableValue Acceleration;
	[SerializeField] protected ScriptableValue Threat;


	public IEntity Create(IEntity entity)
	{
		IEntity face = new Entity(Id, entity.Owner);
		face.AddComponent<INameComponentProxy>(new NameComponentProxy(Name, Image));
		face.AddComponent<IStageComponentProxy>(new StageComponentProxy(Stage));
		if (null != SetupAbility) face.AddComponent<ISetupComponentProxy>(new SetupComponentProxy(SetupAbility.Create(entity)));
		if (null != WhenRevealedAbility) face.AddComponent<IWhenRevealedComponentProxy>(new WhenRevealedComponentProxy(WhenRevealedAbility.Create(entity)));
		if (IsScheme)
		{
			face.AddComponent<IThresholdAccelerationComponentProxy>(new ThresholdAccelerationComponentProxy(Threshold.GetValue(), Acceleration.GetValue()));
			face.AddComponent<IThreatComponentProxy>(new ThreatComponentProxy(Threat.GetValue()));
		}

		return (face);
	}
}
