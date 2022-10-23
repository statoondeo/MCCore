public class PlusOneAtkComponentDecorator : BaseAttackComponentDecorator
{
	public override int Atk => Inner.Atk + 1;

	public PlusOneAtkComponentDecorator(IActivable owner) : base(owner) { }
}
