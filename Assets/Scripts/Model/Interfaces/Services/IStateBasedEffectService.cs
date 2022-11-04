public interface IStateBasedEffectService : IService
{
	void Check();
	void Mute();
	void UnMute();
	IStateBasedEffect Register(IStateBasedEffect stateBasedEffect);
	void UnRegister(IStateBasedEffect stateBasedEffect);
}
