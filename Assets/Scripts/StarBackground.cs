using UnityEngine;

[System.Serializable]
public class StarBackgroundLayer
{
	public float Speed = 1;
}

public class StarBackground : MonoBehaviour
{
	public StarBackgroundLayer [] Layers;
	public Vector3 StartingVelocity;

	Vector3 Velocity;

	void Start()
	{
		Velocity = StartingVelocity;
	}

	void Update()
	{
		float dt = Time.deltaTime;

		UpdateScroll(dt);
	}

	void UpdateScroll(float dt)
	{
		Vector3 movement = Vector3.zero;

		for (int i=0; i < Layers.Length; i++) 
		{
			var layer = Layers[i];

			movement *= (layer.Speed * dt);
		
			var pos = transform.localPosition;
			pos += movement;
			transform.localPosition = pos;
		}
	}
}