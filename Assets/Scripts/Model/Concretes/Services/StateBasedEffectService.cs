using System;

public class StateBasedEffectService : TankService<IStateBasedEffect>, IStateBasedEffectService
{
	protected Action CheckAction;

	public StateBasedEffectService() : base() => Mute();

	public void Check() => CheckAction.Invoke();
	protected void UnMutedCheck()
	{
		bool redo;
		do
		{
			redo = false;
			for (int i = 0; i < Count; i++) redo = Get(i).Check() || redo;
		} while (redo);
	}
	public IStateBasedEffect Register(IStateBasedEffect stateBasedEffect) => Add(stateBasedEffect);
	public void UnRegister(IStateBasedEffect stateBasedEffect) => Remove(stateBasedEffect);
	public void Mute() => CheckAction = () => { };
	public void UnMute() => CheckAction = UnMutedCheck;
	public override IService Initialize()
	{
		Register(new CharacterDefeatedStateBasedEffect());
		Register(new SideSchemeDefeatedStateBasedEffect());
		return base.Initialize();
	}
}
