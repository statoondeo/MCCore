using System;

public interface IMessageService : IService
{
	void Raise((MessageType, string) eventName);
	void Raise((MessageType, string) eventName, MessageArg eventArg);
	void Register((MessageType, string) eventToListen, Action<MessageArg> callback);
	void UnRegister((MessageType, string) eventToListen, Action<MessageArg> callback);
}