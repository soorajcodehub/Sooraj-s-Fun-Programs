using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunPrograms
{
	public class LRUDictionary<T,K>
	{
		public Dictionary<T,K> _dictionary;
		public  LRUDictionary()
		{
			 _dictionary = new Dictionary<T,K>();
		}

	}
}
