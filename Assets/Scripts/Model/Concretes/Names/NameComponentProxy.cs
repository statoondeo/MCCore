using System.Text;
using UnityEngine;

public class NameComponentProxy : BaseComponentProxy<INameComponent>, INameComponentProxy
{
	public string Name => Wrapped.Name;
	public Sprite Image => Wrapped.Image;

	public NameComponentProxy(string name, Sprite image) : base(new NameComponent(name, image)) { }

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t NameComponentProxy");
		sb.AppendLine($"\t\t Name={Name}");
		sb.AppendLine($"\t\t Image={Image}");
		return (sb.ToString());
	}
}
