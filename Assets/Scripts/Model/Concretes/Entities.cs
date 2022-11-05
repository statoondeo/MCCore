public static class Entities
{
	#region Helpers

	public static T GetActiveFaceComponent<T>(this IEntity entity) where T : class
		=> entity.GetComponent<T>() ?? entity.GetComponent<IFaceContainerComponentProxy>()?.ActiveFace.Face.GetComponent<T>();

	#endregion
}
