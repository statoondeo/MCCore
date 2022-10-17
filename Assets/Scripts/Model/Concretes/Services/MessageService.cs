using System;
using System.Collections.Generic;
using UnityEngine;

public class MessageService : IMessageService
{
	protected readonly Dictionary<(MessageType, string), Message> MessagesAtlas;

	public MessageService() => MessagesAtlas = new Dictionary<(MessageType, string), Message>();

	protected Message GetEvent((MessageType, string) eventName) => MessagesAtlas.TryGetValue(eventName, out Message message) ? message : null;

	public void Raise((MessageType, string) eventName) => Raise(eventName, MessageArg.Empty);
	public void Raise((MessageType, string) eventName, MessageArg eventArg)
	{
		Debug.Log($"Raise {eventName.Item1}/{eventName.Item2}");
		GetEvent(eventName)?.Raise(eventArg);
	}
	public void Register((MessageType, string) eventToListen, Action<MessageArg> callback)
	{
		Message message = GetEvent(eventToListen);
		if (null == message)
		{
			message = new Message();
			MessagesAtlas.Add(eventToListen, message);
		}
		message.RegisterListener(callback);
	}
	public void UnRegister((MessageType, string) eventToListen, Action<MessageArg> callback) => GetEvent(eventToListen)?.UnregisterListener(callback);

	public IService Initialize() => this;
}
