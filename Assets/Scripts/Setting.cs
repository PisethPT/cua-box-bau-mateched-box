using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using bau;
using static SaveDateTime;

public class Setting : AudiosSource, ButtonDOA
{
    // public AudiosSource audios;
    public Components components;
    private bool setting_bool;
    public GameObject settingButton, notedPanel;
    public Animator setting_animation;
    public void SettingButton() { Selection(Options.SETTING); playSound.clip = audioClips[0]; playSound.Play(); }

    public void HomeButton() { Selection(Options.HOME); playSound.clip = audioClips[0]; playSound.Play(); }

    public void MusicButton() { Selection(Options.MUSIC); playSound.clip = audioClips[0]; playSound.Play(); }

    public void SoundButton() { Selection(Options.SOUND); playSound.clip = audioClips[0]; playSound.Play(); }

    public void HistoryButton() { Selection(Options.HISTORY); playSound.clip = audioClips[0]; playSound.Play(); }
    public void CloseButton() { Selection(Options.CLOSE); playSound.clip = audioClips[0]; playSound.Play(); }

    public void Selection(Options options)
    {
        SavePointAndTime(components.dice_points);
        notedPanel.SetActive(false);

        if (options.Equals(Options.SETTING))
        {
            setting_bool = !setting_bool;
            if (setting_bool)
            {
                settingButton.SetActive(false);
                setting_animation.Play("setting_open");
            }
            else if (!setting_bool)
            {
                Time.timeScale = 1f;
                setting_animation.Play("setting_off");
                settingButton.SetActive(true);
            }
        }
        else if (options.Equals(Options.HOME))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("main-scene");
        }
        else if (options.Equals(Options.MUSIC))
        {
            Time.timeScale = 0f;
            music_isPlay = !music_isPlay;
            if (music_isPlay)
            {
                music_image.sprite = music_icons[1];
                playMusic.clip = musicClip;
                playMusic.mute = true;
            }
            else if (!music_isPlay)
            {
                music_image.sprite = music_icons[0];
                playMusic.clip = musicClip;
                playMusic.Play();
                playMusic.mute = false;
            }
        }
        else if (options.Equals(Options.SOUND))
        {
            Time.timeScale = 0f;
            sound_isPlay = !sound_isPlay;
            if (sound_isPlay)
            {
                sound_image.sprite = sound_icons[1];
                foreach (var sfx_sounds in audioClips)
                {
                    playSound.clip = sfx_sounds;
                    playSound.mute = true;
                }
            }
            else if (!sound_isPlay)
            {
                sound_image.sprite = sound_icons[0];
                foreach (var sfx_sounds in audioClips)
                {
                    playSound.clip = sfx_sounds;
                    playSound.mute = false;
                }
            }
        }
        else if (options.Equals(Options.HISTORY))
        {
            Time.timeScale = 0f;
            notedPanel.SetActive(true);
            components.date_time_text = PlayerPrefs.GetString(key_dateTime);
            components.noted.GetChild(0).GetComponent<Text>().text = "TODAY: " + components.date_time_text;
            components.history_points = GetPoints();
            for (int i = 0; i < components.noted.GetChild(1).childCount; i++)
            {
                components.noted.GetChild(1).GetChild(i).GetChild(0).GetComponent<Text>().text = components.history_points[i].ToString();
            }
        }
        else if (options.Equals(Options.CLOSE))
        {
            Time.timeScale = 1f;
            notedPanel.SetActive(false);
        }
    }


}
