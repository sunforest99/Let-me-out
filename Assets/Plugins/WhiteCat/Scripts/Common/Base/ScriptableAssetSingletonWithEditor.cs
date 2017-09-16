using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace WhiteCat
{
	/// <summary>
	/// ScriptableAssetSingletonWithEditor
	/// 
	/// 因为在 Unity 中, 没有被场景引用, 或不在 Resources 里的资源在 Build 时会被忽略,
	/// 所以在运行时需要通过场景引用, 或 Resources 加载的方式来创建内存实例.
	/// 此单例类的意义在于, 在编辑器中提供访问实例的方法
	/// </summary>
	public class ScriptableAssetSingletonWithEditor<T> : ScriptableAssetWithEditor, ISerializationCallbackReceiver
		where T : ScriptableAssetSingletonWithEditor<T>
	{
		static T _instance;


		/// <summary>
		/// 访问资源的内存实例
		/// </summary>
		public static T instance
		{
			get
			{
#if UNITY_EDITOR
				if (_instance == null)
				{
					var guids = AssetDatabase.FindAssets("t:" + typeof(T).Name);

					if (Kit.IsNullOrEmpty(guids))
					{
						Debug.LogError("Can not find the asset of type " + typeof(T));
					}
					else
					{
						if (guids.Length > 1)
						{
							Debug.LogError("Too many assets of type " + typeof(T));
						}

						_instance = AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(guids[0]));
					}
				}
#endif
				return _instance;
			}
		}


		public virtual void OnBeforeSerialize()
		{
		}


		public virtual void OnAfterDeserialize()
		{
			_instance = this as T;
		}

	} // class ScriptableAssetSingletonWithEditor

} // namespace WhiteCat