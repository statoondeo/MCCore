using System.Collections.Generic;
using System.Linq;
using System;

public static class Filters
{
	public static bool IdentityFilter(IEntity card)
	{
		ICardType alterEgoCardType = ServiceLocator.Get<ICardTypeService>().Get(CardTypes.ALTER_EGO);
		ICardType heroCardType = ServiceLocator.Get<ICardTypeService>().Get(CardTypes.HERO);

		ICardComponentProxy cardComponentProxy = card.GetComponent<ICardComponentProxy>();
		if (null == cardComponentProxy) return (false);

		return (cardComponentProxy.IsOneOfCardType(alterEgoCardType, heroCardType));
	}
	public static bool NemesisFilter(IEntity card)
	{
		IClassification nemesisClassification = ServiceLocator.Get<IClassificationService>().Get(Classifications.NEMESIS);

		ICardComponentProxy cardComponentProxy = card.GetComponent<ICardComponentProxy>();
		if (null == cardComponentProxy) return (false);

		return (cardComponentProxy.IsClassification(nemesisClassification));
	}
	public static bool ObligationFilter(IEntity card)
	{
		ICardType obligationCardType = ServiceLocator.Get<ICardTypeService>().Get(CardTypes.OBLIGATION);

		ICardComponentProxy cardComponentProxy = card.GetComponent<ICardComponentProxy>();
		if (null == cardComponentProxy) return (false);

		return (cardComponentProxy.IsCardType(obligationCardType));
	}
	public static IEntity GetFirst(Func<IEntity, bool> filter, IList<IEntity> dataSet)
	{
		for (int i = 0; i < dataSet.Count; i++)
		{
			IFaceContainerComponentProxy faceContainer = dataSet[i].GetComponent<IFaceContainerComponentProxy>();
			IList<string> faces = faceContainer.Faces.Keys.ToList();
			for (int j = 0; j < faces.Count; j++)
				if (filter.Invoke(faceContainer.Faces[faces[j]].Face)) return (dataSet[i]);
		}

		return (null);
	}
	public static IList<IEntity> GetAll(Func<IEntity, bool> filter, IList<IEntity> dataSet)
	{
		IList<IEntity> filteredDataSet = new List<IEntity>();
		for (int i = 0; i < dataSet.Count; i++)
		{
			IFaceContainerComponentProxy faceContainer = dataSet[i].GetComponent<IFaceContainerComponentProxy>();
			IList<string> faces = faceContainer.Faces.Keys.ToList();
			for (int j = 0; j < faces.Count; j++)
				if (filter.Invoke(faceContainer.Faces[faces[j]].Face)) filteredDataSet.Add(dataSet[i]);
		}

		return (filteredDataSet);
	}
}
