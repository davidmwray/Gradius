using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager Inst { get; private set; }

	void Awake()
	{
		Inst = this;
	}

	void Start()
	{
	}

	void Update()
	{
		float dt = Time.deltaTime;
	}

	public void PlaySound(string soundName)
	{
		var sound = FindSound("SFX-" + soundName);
		sound.Play();
	}

	public void StopSound(string soundName)
	{
		var sound = FindSound("SFX-" + soundName);
		sound.Stop();
	}

	public void PlayMusic(string musicName)
	{
		var music = FindSound("BGM-" + musicName);
		music.Play();
	}

	public void StopMusic(string musicName)
	{
		var music = FindSound("BGM-" + musicName);
		music.Stop();
	}

	public AudioSource FindSound(string soundName)
	{
		return transform.FindChild(soundName).gameObject.GetComponent<AudioSource>();
	}
}