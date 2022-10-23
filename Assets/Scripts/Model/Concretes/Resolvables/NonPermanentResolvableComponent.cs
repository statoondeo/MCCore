public class NonPermanentResolvableComponent : BaseResolvableComponent
{
	public NonPermanentResolvableComponent() { }

	public override void Cancel()
	{
		IBasicComponent basicComponent = Entity.GetComponent<IBasicComponent>();
		basicComponent.MoveTo("DISCARD");
	}

	public override void Resolve()
	{
		IBasicComponent basicComponent = Entity.GetComponent<IBasicComponent>();
		basicComponent.MoveTo("DISCARD");
	}
}
