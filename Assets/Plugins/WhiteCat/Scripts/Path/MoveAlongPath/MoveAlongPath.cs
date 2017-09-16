using System.Collections.Generic;
using UnityEngine;

namespace WhiteCat.Paths
{
	/// <summary>
	/// 在路径上移动
	/// </summary>
	[AddComponentMenu("White Cat/Path/Move Along Path")]
	[DisallowMultipleComponent]
	public partial class MoveAlongPath : ScriptableComponentWithEditor
	{
		[SerializeField] Path _path = null;
		[SerializeField] float _distance = 0;
		[SerializeField] Location _location = new Location();

		[SerializeField] float _speed = 1f;
		[SerializeField] UpdateMode _updateMode = UpdateMode.Update;
		[SerializeField] TimeMode _timeMode = TimeMode.Normal;

		[SerializeField] List<KeyframeListTargetComponentPair> _pairs = new List<KeyframeListTargetComponentPair>(4);


		/// <summary>
		/// 引用的路径
		/// </summary>
		public Path path
		{
			get { return _path; }
			set
			{
				if (_path != value)
				{
					if (value && value.transform.IsChildOf(transform))
					{
						Debug.LogError("The Path can neither be on itself, nor its children.");
						return;
					}

					_path = value;
					_pairs.Clear();
					Sync();
				}
			}
		}


		/// <summary>
		/// 从路径起点开始的距离
		/// </summary>
		public float distance
		{
			get { return _distance; }
			set
			{
				_distance = value;
				Sync();
            }
		}


		/// <summary>
		/// 路径位置参数
		/// </summary>
		public Location location
		{
			get { return _location; }
		}


		/// <summary>
		/// 移动速度
		/// </summary>
		public float speed
		{
			get { return _speed; }
			set { _speed = value; }
		}


		/// <summary>
		/// 更新模式
		/// </summary>
		public UpdateMode updateMode
		{
			get { return _updateMode; }
			set { _updateMode = value; }
		}


		/// <summary>
		/// 时间模式
		/// </summary>
		public TimeMode timeMode
		{
			get { return _timeMode; }
			set { _timeMode = value; }
		}


		/// <summary>
		/// 立即执行同步, 当路径发生变化后可手动执行
		/// </summary>
		public void Sync()
		{
			if (_path)
			{
				if (!_path.circular) _distance = Mathf.Clamp(_distance, 0f, _path.length);

				_location = _path.GetLocationByLength(_distance, _location.index);
				transform.position = _path.GetPoint(_location);

				// 更新移动数据块
				KeyframeListTargetComponentPair pair;
				for (int i=0; i<_pairs.Count; i++)
				{
					pair = _pairs[i];
					if (pair.keyframeList && pair.targetComponent)
					{
						pair.keyframeList.UpdateMovingObject(pair, this);
					}
					else
					{
						_pairs.RemoveAt(i--);
					}
				}
			}
		}


		/// <summary>
		/// 添加移动对象. 物体移动中会计算路径关键帧插值并应用到目标组件上
		/// </summary>
		public bool AddMovingObject(Path.KeyframeList keyframeList, Component target)
		{
			if (_path && keyframeList && target
				&& keyframeList.path == _path
				&& keyframeList.targetComponentType.IsInstanceOfType(target)
				&& !_pairs.Exists(item => item.keyframeList == keyframeList))
			{
				var movingObject = new KeyframeListTargetComponentPair();
				movingObject.keyframeList = keyframeList;
				movingObject.targetComponent = target;
				_pairs.Add(movingObject);

				return true;
			}
			else return false;
		}


		/// <summary>
		/// 移除移动对象
		/// </summary>
		public void RemoveMovingObject(Path.KeyframeList keyframeList)
		{
			_pairs.RemoveAll(item => item.keyframeList == keyframeList);
		}


		/// <summary>
		/// 移除移动对象
		/// </summary>
		public void RemoveMovingObject(Component target)
		{
			_pairs.RemoveAll(item => item.targetComponent == target);
		}


		void Update()
		{
			if (_updateMode == UpdateMode.Update)
			{
				distance += _speed * (_timeMode == TimeMode.Normal ? Time.deltaTime : Time.unscaledDeltaTime);
			}
        }


		void LateUpdate()
		{
			if (_updateMode == UpdateMode.LateUpdate)
			{
				distance += _speed * (_timeMode == TimeMode.Normal ? Time.deltaTime : Time.unscaledDeltaTime);
			}
		}


		void FixedUpdate()
		{
			if (_updateMode == UpdateMode.FixedUpdate)
			{
				distance += _speed * Time.fixedDeltaTime;
			}
		}

	} // class MoveAlongPath

} // namespace WhiteCat.Paths