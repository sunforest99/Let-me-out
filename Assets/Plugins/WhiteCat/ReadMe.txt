--------------------------<<<<< Version 3.4 >>>>>--------------------------

Cautions:
	This version is NOT backwards compatible.

Detail:
	Add modularized namespace for scripts.
	Change MaterialType.Shared to Specified, add new RendererShared type.
	Add Gradient for TweenColor.
	Use LinkedList improve GameObjectPool.
	Add Scenes script (Assets -> Create -> White Cat -> Scenes Script).
	Add UpdateMode for Tweener.
	Fix Quaternion lerp-method from Lerp to Slerp in RotationKeyframeList.
	Fix default value of rotation is invalid in RotationKeyframeList.
	Fix Path gizmos error.
	Fix CreateAsset error.
	Improve FSM.
	ViewDetector was removed. A better Vision System is in development.




--------------------------<<<<< Version 3.3 >>>>>--------------------------

Detail:
	Fix bug of multi-inspector drawing.
	Repaint Inspector when Toggle.currentValue changed.
	Modify file extensions of assets which created by QuickCreateAsset.




--------------------------<<<<< Version 3.2 >>>>>--------------------------

Detail:
	Add CardinalPath component (and example).
	Add new example about scripting of Path.
	Fix bug of GetSetAttribute of example script.
	Fix bug of SetCardinalCurve of CubicSpline.




--------------------------<<<<< Version 3.1 >>>>>--------------------------

Detail:
	Add ViewDetector component (and example).
	Add GameObjectPool component (and example).
	Add Toggle component.
	Add MoveSpeedKeyframeList component.
	Add global Tween animations (ambient, fog, etc).
	Add TweenCameraFieldOfView component.
	Add TweenCameraBackgroundColor component.
	Add TweenLightShadowStrength component (update example).
	Add TweenSpriteRendererColor component (update example).
	Change base class of State and stateMachine.
	Draw an arrow at end of path, for distinguishing direction.




--------------------------<<<<< Version 3.0 >>>>>--------------------------

Cautions:
	Required version of Unity upgraded to 5.2.0.
	This version is NOT backwards compatible.

Detail:
	Totally refactor.
	Add State Machine and Stack State Machine.
	Redesign Path and Tween.