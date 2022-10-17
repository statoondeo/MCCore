//using System.Collections.Generic;
//using UnityEngine;

//public class CardComponentDecoratorAttacherDecorator<T> : BaseCardComponentDecorator where T : IComponent
//{
//	protected IComponentProxy<T> TargetComponent;
//	protected IComponentDecorator<T> AttachedDecorator;
//	protected BaseDecoratorFactoryScriptable<T> DecoratorFactory;

//	public CardComponentDecoratorAttacherDecorator(IActivable owner, BaseDecoratorFactoryScriptable<T> decoratorFactory) : base(owner) => DecoratorFactory = decoratorFactory;

//	public override void Resolve()
//	{
//		Inner.Resolve();
//		IList<IEntity> targets = ServiceLocator.Get<IEntityService>().Get();
//		IEntity target = null;
//		ICardType heroCardType = Resources.Load<ScriptableCardType>("CardTypes/Hero").Create();
//		for (int i = 0; i < targets.Count; i++)
//		{
//			IFaceContainerComponentProxy faceContainer = targets[i].GetComponent<IFaceContainerComponentProxy>();
//			IEntity currentTarget = null == faceContainer ? targets[i] : faceContainer.ActiveFace.Face;

//			ICardComponentProxy cardComponent = currentTarget.GetComponent<ICardComponentProxy>();
//			if ((null != cardComponent) && (cardComponent.CardType == heroCardType))
//			{
//				target = faceContainer.ActiveFace.Face;
//				break;
//			}
//		}
//		if (null == target) return;

//		IList<IComponent> components = target.GetComponents();
//		for (int i = 0; i < components.Count; i++)
//		{
//			if (components[i] is IComponentProxy<T> componentProxy)
//			{
//				TargetComponent = componentProxy;
//				AttachedDecorator = DecoratorFactory.Create(Owner);
//				componentProxy.Register(AttachedDecorator);
//				break;
//			}
//		}
//	}
//	public override void Discard()
//	{
//		if ((null != TargetComponent) && (null != AttachedDecorator)) TargetComponent.UnRegister(AttachedDecorator);
//		Inner.Discard();
//	}
//}
