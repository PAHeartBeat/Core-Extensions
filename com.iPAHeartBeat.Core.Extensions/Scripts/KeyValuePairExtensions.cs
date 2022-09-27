using System.Collections.Generic;

namespace iPAHeartBeat.Core.Extensions {
	/// <summary>
	/// Common Operation form Key-value pair object like Dictionary or IDictionary
	/// </summary>
	public static class KeyValuePairExtensions {
		/// <summary>
		/// Will merge a dictatory to another one
		/// </summary>
		/// <typeparam name="K">Type of the Key in Dictionary</typeparam>
		/// <typeparam name="V">Type of the value in Dictionary</typeparam>
		/// <param name="target">Target dictionary in which data from source dictionary will be merged</param>
		/// <param name="source">Source dictionary of which data should be merged with target one.</param>
		/// <returns>Updated Dictionary</returns>
		public static Dictionary<K, V> Merge<K, V>(this Dictionary<K, V> target, Dictionary<K, V> source)
			=> target.Merge(source, false);

		/// <summary>
		/// Will merge a dictatory to another one
		/// </summary>
		/// <typeparam name="K">Type of the Key in Dictionary</typeparam>
		/// <typeparam name="V">Type of the value in Dictionary</typeparam>
		/// <param name="target">Target dictionary in which data from source dictionary will be merged</param>
		/// <param name="source">Source dictionary of which data should be merged with target one.</param>
		/// <param name="removeIsSourceHasNotValue">Should remove data from source dictionary which are not in other dictionary</param>
		/// <returns>Updated Dictionary</returns>
		public static Dictionary<K, V> Merge<K, V>(this Dictionary<K, V> target, Dictionary<K, V> source, bool removeIsSourceHasNotValue) {
			if (target.IsNull()) {
				target = new Dictionary<K, V>();
			}

			if (source.IsNull()) {
				return target;
			}

			if (removeIsSourceHasNotValue) {
				target.Copy(source);
				return target;
			}

			foreach (K key in source.Keys) {
				target[key] = source[key];
			}
			return target;
		}

		/// <summary>
		/// Will to Value copy to avoid referace link with two dictionary
		/// </summary>
		/// <typeparam name="K">Type of the Key in Dictionary</typeparam>
		/// <typeparam name="V">Type of the value in Dictionary</typeparam>
		/// <param name="target">Target dictionary in which data from source dictionary will be copied</param>
		/// <param name="source">Source dictionary of which data should be copied</param>
		/// <returns>Updated Dictionary</returns>
		public static Dictionary<K, V> Copy<K, V>(this Dictionary<K, V> target, Dictionary<K, V> source) {
			if (target.IsNull()) {
				target = new Dictionary<K, V>();
			} else {
				target.Clear();
			}

			if (source.IsNull()) {
				return target;
			}

			foreach (K key in source.Keys) {
				target[key] = source[key];
			}
			return target;
		}
	}
}
