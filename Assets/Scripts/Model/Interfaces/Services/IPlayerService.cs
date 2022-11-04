public interface IPlayerService : IIndexedTank<IPlayer, string>, IService 
{
	void Initialize(params IPlayer[] players);
}
