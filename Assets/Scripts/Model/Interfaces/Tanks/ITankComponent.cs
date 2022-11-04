using System.Collections.Generic;

public interface ITankComponent : IComponent, ITank<IEntity>
{
	IList<IEntity> Get(IFilterStrategy filter);
	IEntity GetFirst(IFilterStrategy filter);
}