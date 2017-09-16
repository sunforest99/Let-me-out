using UnityEngine;
using WhiteCat.Paths;

public class PingPongMoveAlongPath : MonoBehaviour
{
	MoveAlongPath move;


	void Awake()
	{
		move = GetComponent<MoveAlongPath>();
	}


	void LateUpdate()
	{
		if (move.distance <= 0f)
		{
			move.speed = 1.25f;
		}
		else if (move.distance >= move.path.length)
		{
			move.speed = -1.25f;
		}
	}
}