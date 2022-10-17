using UnityEngine;

[CreateAssetMenu(fileName = "+1 Atk Modifier", menuName = "Modifier/Attack")]
public class PlusOneAtkModifierScriptable : BaseDecoratorFactoryScriptable<IAttackComponent>
{
	public override IComponentDecorator<IAttackComponent> Create(IActivable owner) => new PlusOneAtkComponentDecorator(owner);
}
