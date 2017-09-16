#if UNITY_EDITOR

using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using WhiteCatEditor;

namespace WhiteCat.Paths
{
	/// <summary>
	/// MoveAlongPathEditor
	/// </summary>
	public partial class MoveAlongPath
	{
		static GUIContent _buttonContent = new GUIContent("Sync",
			"If you had modified the Path, click this button to sync position of Transform.");

		static Color _tableBackgroundColor = new Color(0.5f, 0.5f, 0.5f, 0.25f);
		static List<Path.KeyframeList> _keyframeLists = new List<Path.KeyframeList>(4);

		SerializedProperty _speedProperty;
		SerializedProperty _updateModeProperty;
		SerializedProperty _timeModeProperty;


		protected override void Editor_OnEnable()
		{
			_speedProperty = editor.serializedObject.FindProperty("_speed");
			_updateModeProperty = editor.serializedObject.FindProperty("_updateMode");
			_timeModeProperty = editor.serializedObject.FindProperty("_timeMode");
		}


		protected override void Editor_OnDisable()
		{
			_speedProperty = null;
			_updateModeProperty = null;
			_timeModeProperty = null;
		}


		protected override void Editor_OnInspectorGUI()
		{
			// path
			editor.DrawObjectFieldLayout(_path, value => path = value, "Path");

			// distance
			EditorGUI.BeginChangeCheck();
			var distance = EditorGUILayout.FloatField("Distance", _distance);
			if (EditorGUI.EndChangeCheck())
			{
				Undo.RecordObject(transform, editor.undoString);
				Undo.RecordObject(this, editor.undoString);
				this.distance = distance;
				EditorUtility.SetDirty(transform);
				EditorUtility.SetDirty(this);
			}

			// speed & timeMode
			editor.serializedObject.Update();
			EditorGUILayout.PropertyField(_speedProperty);
			EditorGUILayout.PropertyField(_updateModeProperty);
			EditorGUI.BeginDisabledGroup(_updateMode == UpdateMode.FixedUpdate);
			EditorGUILayout.PropertyField(_timeModeProperty);
			EditorGUI.EndDisabledGroup();
			editor.serializedObject.ApplyModifiedProperties();

			// sync button
			Rect rect = EditorGUILayout.GetControlRect(true);
			rect.xMin += EditorGUIUtility.labelWidth;
			if (GUI.Button(rect, _buttonContent, EditorStyles.miniButton))
			{
				Undo.RecordObject(transform, editor.undoString);
				Undo.RecordObject(this, editor.undoString);
				Sync();
				EditorUtility.SetDirty(transform);
				EditorUtility.SetDirty(this);
			}

			// keyframe list
			if (_path)
			{
				_keyframeLists.Clear();
				_path.GetComponents(_keyframeLists);

				if (_keyframeLists.Count > 0)
				{
					// 计算表格大小

					EditorGUILayout.Space();
					float lineHeight = EditorGUIUtility.singleLineHeight;
					rect = EditorGUILayout.GetControlRect(true, (lineHeight + 1f) * (_keyframeLists.Count + 1) + 4f);
					Rect left = new Rect(rect.x, rect.y, rect.width * 0.5f, lineHeight);
					Rect right = new Rect(left.xMax, left.y, left.width, lineHeight);

					// 绘制背景和线条

					EditorGUI.DrawRect(rect, _tableBackgroundColor);
					float yMax = rect.yMax;
					rect.height = 1f;
					Color lineColor = EditorKit.defaultContentColor * 0.5f;
					EditorGUI.DrawRect(rect, lineColor);
					rect.y += lineHeight + 1f;
					EditorGUI.DrawRect(rect, lineColor);
					rect.y = yMax;
					EditorGUI.DrawRect(rect, lineColor);

					// 绘制标题

					EditorGUI.LabelField(left, "Keyframe List", EditorKit.centeredBoldLabelStyle);
					EditorGUI.LabelField(right, "Target Component", EditorKit.centeredBoldLabelStyle);

					left.y += 3f;
					right.y += 3f;

					// 计算左列宽度

					rect = left;
					rect.width = lineHeight;
					left.xMin += lineHeight + 2f;

					// 绘制行元素

					Path.KeyframeList keyframeList;
					KeyframeListTargetComponentPair pair;

					for (int i=0; i<_keyframeLists.Count; i++)
					{
						rect.y += lineHeight + 1f;
						left.y += lineHeight + 1f;
						right.y += lineHeight + 1f;

						keyframeList = _keyframeLists[i];

						// 绘制个性色

						EditorKit.RecordAndSetGUIColor(EditorKit.defaultContentColor);
						GUI.DrawTexture(rect, EditorAssets.bigDiamondTexture);
						EditorKit.RestoreGUIColor();

						EditorKit.RecordAndSetGUIColor(keyframeList.personalizedColor);
						GUI.DrawTexture(rect, EditorAssets.smallDiamondTexture);
						EditorKit.RestoreGUIColor();

						// 绘制关键帧列表名

						EditorGUI.LabelField(left, keyframeList.targetPropertyName);

						// 绘制目标组件引用

						pair = _pairs.Find(item => item.keyframeList == keyframeList);

						if (pair == null)
						{
							EditorGUI.BeginChangeCheck();
							var target = EditorGUI.ObjectField(right, null, keyframeList.targetComponentType, !EditorUtility.IsPersistent(this));
							if (EditorGUI.EndChangeCheck())
							{
								if (target)
								{
									Undo.RecordObject(this, editor.undoString);
									AddMovingObject(keyframeList, target as Component);
									EditorUtility.SetDirty(this);
									editor.Repaint();
									break;
								}
							}
						}
						else
						{
							EditorGUI.BeginChangeCheck();
							var target = EditorGUI.ObjectField(right, pair.targetComponent, keyframeList.targetComponentType, !EditorUtility.IsPersistent(this));
							if (EditorGUI.EndChangeCheck())
							{
								Undo.RecordObject(this, editor.undoString);

								if (target) pair.targetComponent = target as Component;
								else _pairs.Remove(pair);

								EditorUtility.SetDirty(this);
								editor.Repaint();
								break;
							}
						}
					}

					EditorGUILayout.Space();
				}
			}
		}

	} // class MoveAlongPath

} // namespace WhiteCat.Paths

#endif // UNITY_EDITOR