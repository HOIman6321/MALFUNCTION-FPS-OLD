using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
	public AudioMixer mixer;
	public Slider slider;
	public PostProcessVolume volume;

	private Bloom bloomEffect;
	private ColorGrading colorGradingEffect;
	private MotionBlur motionBlurEffect;

	public TMP_Dropdown resolutionDropdown;

	Resolution[] resolutions;

	// bool isBloomOn = true;
	// bool isColorGradingOn = true;
	// bool isMotionBlurOn = true;

	int boolToInt(bool val)
	{
	    if (val)
	        return 1;
	    else
	        return 0;
	}

	bool intToBool(int val)
	{
	    if (val != 0)
	        return true;
	    else
	        return false;
	}

	void Start()
	{
		slider.value = PlayerPrefs.GetFloat("Volume", 0.75f);
		// volume.profile.TryGetSettings(out bloomEffect);
		// volume.profile.TryGetSettings(out colorGradingEffect);
		// volume.profile.TryGetSettings(out motionBlurEffect);
		resolutions = Screen.resolutions;

		resolutionDropdown.ClearOptions();

		List<string> options = new List<string>();

		int currentResolutionIndex = 0;

		for (int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + "x" + resolutions[i].height;
			options.Add(option);

			if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
			{
				currentResolutionIndex = i;
			}
		}

		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue();
	}

	public void SetResolution (int resolutionIndex)
	{
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width, resolution.height, true);
	}

	void Update()
	{
		// bloomEffect.enabled.Override(isBloomOn);
		// colorGradingEffect.enabled.Override(isColorGradingOn);
		// motionBlurEffect.enabled.Override(isMotionBlurOn);
		SetVolume(slider.value);
	}

	public void SetVolume(float volume)
	{
		mixer.SetFloat("Volume", volume);
		PlayerPrefs.SetFloat("Volume", volume);
	}

	// public void ToggleBloom()
	// {
	// 	isBloomOn = !isBloomOn;
	// 	PlayerPrefs.SetInt("IsBloomOn", boolToInt(isBloomOn));
	// }

	// public void ToggleColorGrading()
	// {
	// 	isColorGradingOn = !isColorGradingOn;
	// 	PlayerPrefs.SetInt("IsColorGradingOn", boolToInt(isColorGradingOn));
	// }

	// public void ToggleMotionBlur()
	// {
	// 	isMotionBlurOn = !isMotionBlurOn;
	// 	PlayerPrefs.SetInt("IsMotionBlurOn", boolToInt(isMotionBlurOn));
	// }

	// public void DoPlayerPrefs()
	// {
	// 	isBloomOn = intToBool(PlayerPrefs.GetInt("IsBloomOn"));
	// 	isColorGradingOn = intToBool(PlayerPrefs.GetInt("IsColorGradingOn"));
	// 	isMotionBlurOn = intToBool(PlayerPrefs.GetInt("IsMotionBlurOn"));
	// }


}
