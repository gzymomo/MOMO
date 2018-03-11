﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MOMO.Infrastructure.Utilities
{
    public class TreeItem<T>
    {
        public T Item { get; set; }
        public IEnumerable<TreeItem<T>> Children { get; set; }
    }


	/// <summary>
	/// List转成Tree
	/// </summary>
	public static class TreeHelpers
	{
		/// <summary>
		/// Generates tree of items from item list
		/// </summary>
		/// 
		/// <typeparam name="T">Type of item in collection</typeparam>
		/// <typeparam name="K">Type of parent_id</typeparam>
		/// 
		/// <param name="collection">Collection of items</param>
		/// <param name="idSelector">Function extracting item's id</param>
		/// <param name="parentIdSelector">Function extracting item's parent_id</param>
		/// <param name="rootId">Root element id</param>
		/// 
		/// <returns>Tree of items</returns>
		public static IEnumerable<TreeItem<T>> GenerateTree<T, K>(
			this IEnumerable<T> collection,
			Func<T, K> idSelector,
			Func<T, K> parentIdSelector,
			K rootId = default(K))
		{
			foreach (var c in collection.Where(c => parentIdSelector(c).Equals(rootId)))
			{
				yield return new TreeItem<T>
				{
					Item = c,
					Children = collection.GenerateTree(idSelector, parentIdSelector, idSelector(c))
				};
			}
		}
	}

}