using UnityEngine;

public class Player : MonoBehaviour
{
	public float Speed = 2f;

	Vector3 PositionPrev;
	Vector3 Velocity;

	void Start()
	{
	}

	void Update()
	{
		float dt = Time.deltaTime;

		UpdateMovement(dt);
	}

	void UpdateMovement(float dt)
	{
		Vector3 movement = Vector3.zero;
		var val = Input.GetAxis("Horizontal");
		if (val != 0) 
		{
			movement.x += val;
		}
		val = Input.GetAxis("Vertical");
		if (val != 0) 
		{
			movement.y += val;
		}
		
		PositionPrev = transform.localPosition;
		
		movement *= (Speed * dt);
		
		var pos = transform.localPosition;
		pos += movement;
		transform.localPosition = pos;
	}
}