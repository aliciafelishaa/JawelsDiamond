using JawelsDiamond.Model;
using JawelsDiamond.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JawelsDiamond.Handler
{
	public class JewelsHandler
	{

		public static List <MsJewel> getJewelsItem()
		{
			List<MsJewel> jewels = JewelsRepository.getJewel();

			if(jewels == null)
			{
                return new List<MsJewel>();
            }
			return jewels;
		}
	}
}