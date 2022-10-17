﻿using UnityEngine;

public class CardTypeService : IndexedTankService<ICardType, string>, ICardTypeService
{
	public static readonly string CARDTYPE_PATH = "CardTypes";

	public override IService Initialize()
	{
		ScriptableCardType[] items = Resources.LoadAll<ScriptableCardType>(CARDTYPE_PATH);
		for (int i = 0; i < items.Length; i++)
		{
			ICardType item = items[i].Create();
			Add(item.Key, item);
		}
		return (this);
	}
}
