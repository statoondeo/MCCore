using System;
using System.Collections.Generic;

public class ServiceLocator
{
	private static readonly Dictionary<Type, IService> ServicesDictionary;

	static ServiceLocator() => ServicesDictionary = new Dictionary<Type, IService>();

	public static T Get<T>() where T : class => ServicesDictionary[typeof(T)] as T;
	public static T Register<T>(T service) where T : IService
	{
		ServicesDictionary.Add(typeof(T), service);
		return (service);
	}
	public static void UnRegister<T>() where T : IService => ServicesDictionary.Remove(typeof(T));
}
