using UnityEngine;

public class Game : MonoBehaviour
{
	public GameObject BW;
	public float BWTimer = 4f;

	void Start()
	{
		SoundManager.Inst.PlayMusic("Stage1");
	}

	void Update()
	{
		float dt = Time.deltaTime;

		//UpdateBW (dt);
	}

	void UpdateBW(float dt)
	{
		if (BWTimer > 0f)
		{
			BWTimer -= dt;
			if (BWTimer <= 0f)
			{
				ActivateBW();
			}
		}
	}

	void ActivateBW()
	{
		if (BW != null)
		{
			BW.SetActive(true);
			SoundManager.Inst.StopMusic("Stage1");
			SoundManager.Inst.PlaySound("Wilhelm");
		}
	}
}