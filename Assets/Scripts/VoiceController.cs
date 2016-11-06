﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chinen
{
	/// <summary>
	/// Voice controller.
	/// </summary>
	[RequireComponent (typeof(PlayerController), typeof(AudioSource))]
	public class VoiceController : MonoBehaviour
	{
		[SerializeField]
		private AudioClip damageVoice;

		[SerializeField]
		private AudioClip[] jumpVoices;

		[SerializeField]
		private AudioClip clearVoice;

		[SerializeField]
		private AudioClip timeOverVoice;

		private AudioSource audioSource;

		void Awake ()
		{
			audioSource = GetComponent<AudioSource> ();
		}

		void OnDamage ()
		{
			PlayVoice (damageVoice);
		}

		void Jump ()
		{
			int i = Random.Range (0, jumpVoices.Length);
			PlayVoice (jumpVoices [i]);
		}

		void Clear ()
		{
			PlayVoice (clearVoice);
		}

		void TimeOver ()
		{
			PlayVoice (timeOverVoice);
		}

		void PlayVoice (AudioClip voice)
		{
			audioSource.Stop ();
			audioSource.PlayOneShot (voice);
		}
	}
}