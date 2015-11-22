using UnityEngine;
using System;

public class Player : MonoBehaviour
{
	public float Speed = 2f;
	public GameObject StartPos;

	Vector3 PositionPrev;
	[HideInInspector]
	public static Vector3 Velocity;
	Vector3 DashVelocity;

	float DashTimer;

	DateTime DashInputLast;
	public float DashInputWindow;


	void Start()
	{
		transform.position = StartPos.transform.position;
	}

	void Update()
	{
		float dt = Time.deltaTime;
		UpdateDashInput(dt);
		UpdateMovement(dt);
		UpdateDash(dt);
	}

	void UpdateMovement(float dt)
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			transform.position = StartPos.transform.position;
		}

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

		movement *= (Speed * dt);

		movement += DashVelocity * dt;

		var pos = transform.localPosition;
		pos += movement;
		transform.localPosition = pos;

		Velocity = transform.localPosition - PositionPrev;

		PositionPrev = transform.localPosition;
	}

	void UpdateDashInput(float dt)
	{
		if (Input.GetKeyDown (KeyCode.D)) 
		{
			var time = DateTime.Now;
			var timeDelta = time - DashInputLast;

			if (timeDelta.TotalSeconds < DashInputWindow)
			{
				DoDash();
				DashInputLast = DateTime.MinValue;
			}
			else
			{
				DashInputLast = time;
			}
		}
	}

	void UpdateDash(float dt)
	{
		if (DashTimer > 0)
		{
			DashTimer -= dt;
			if (DashTimer <= 0)
			{
				DashVelocity = Vector3.zero;
			}
		}
	}

	void DoDash()
	{
		//Debug.Log("Dash");

		DashVelocity = new Vector3(1000f, 0f, 0f);
		DashTimer = .5f;
	}
}