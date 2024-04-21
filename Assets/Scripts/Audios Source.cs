using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudiosSource : MonoBehaviour
{
    public AudioClip musicClip;
    public AudioClip[] audioClips;
    public AudioSource playSound, playMusic;
    public Sprite[] music_icons;
    public Sprite[] sound_icons;
    public Image music_image, sound_image;
    protected bool music_isPlay, sound_isPlay;
}
