using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class StarBackgroundLayer
{
	public float Speed = 1;
	public float Scale = 1;
	public int NumStars = 50;
	public Color ColorMask;
}

public class StarBackground : MonoBehaviour
{
	public CanvasScaler CanvasScaler;

	public StarBackgroundLayer [] Layers;
	public Vector3 StartingVelocity;
	public GameObject LayerTemplate;
	public GameObject StarTemplate;

	Vector2 ScreenRes;
	Vector3 Velocity;

	void Start()
	{
		Velocity = StartingVelocity;
		ScreenRes.x = CanvasScaler.referenceResolution.x;
		ScreenRes.y = CanvasScaler.referenceResolution.y;

		//Create layers
		for (int i=0; i < Layers.Length; i++) 
		{
			var layerDef = Layers[i];

			var layerGroup = GameObject.Instantiate(LayerTemplate);
			layerGroup.name = "StarLayer" + i;
			layerGroup.transform.SetParent(this.transform);
			layerGroup.transform.localPosition = Vector3.zero;
			layerGroup.transform.localScale = Vector3.one;
			var rectTransform = layerGroup.transform as RectTransform;
			rectTransform.offsetMin = Vector2.zero;
			rectTransform.offsetMax = Vector2.zero;

			for (int starIdx=0; starIdx < layerDef.NumStars; starIdx++)
			{
				UnityEngine.Debug.Log ("ScreenResx: " + ScreenRes.x);

				var starObj = GameObject.Instantiate(StarTemplate);
				starObj.transform.SetParent(layerGroup.transform);
				starObj.transform.localScale = (Vector3.one * layerDef.Scale);
				Vector2 pos = new Vector2(Random.Range(0f, ScreenRes.x), -Random.Range(0f, ScreenRes.y));
				(starObj.transform as RectTransform).anchoredPosition = pos;

				starObj.GetComponent<Image>().color = layerDef.ColorMask;
			}
		}
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
			var layerGroup = this.transform.FindChild("StarLayer" + i);

			for (int starIdx = 0; starIdx < layerGroup.childCount; starIdx++)
			{
				var starObj = layerGroup.GetChild (starIdx);
				Vector3 pos = starObj.localPosition;

				Vector3 vel = (Velocity * Layers[i].Speed);
				pos += (vel * dt);

				starObj.localPosition = pos;
			}
		}
	}
}