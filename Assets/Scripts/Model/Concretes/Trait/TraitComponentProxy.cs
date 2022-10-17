using System.Collections.Generic;
using System.Text;

public class TraitComponentProxy : BaseComponentProxy<ITraitComponent>, ITraitComponentProxy
{
	public IList<ITrait> Traits => Wrapped.Traits;

	public TraitComponentProxy(ITrait[] traits) : base(new TraitComponent(traits)) { }

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t TraitComponentProxy");
		sb.Append("\t\t Traits=");
		for (int i = 0; i < Traits.Count; i++)
			sb.Append(Traits[i]);
		sb.AppendLine();
		return (sb.ToString());
	}
}
