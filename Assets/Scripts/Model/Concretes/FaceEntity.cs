using System.Collections.Generic;
using System.Text;

public class FaceEntity : Entity
{
	public override string ToString()
	{
		StringBuilder sb = new();
		IList<IComponent> components = GetComponents();
		for (int i = 0; i < components.Count; i++)
			sb.Append(components[i]);

		return (sb.ToString());
	}
}
