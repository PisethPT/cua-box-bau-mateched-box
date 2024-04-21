using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManage : MonoBehaviour
{
    public Components components;
    public Setting setting;
    public Sprite[] sprites = new Sprite[3];
    public InstantiateDices instantiateDices;

    private void Awake() {
        Screen.orientation = ScreenOrientation.LandscapeRight;
    }

    private void FixedUpdate()
    {
        if (components.current_time)
        {
            StartCoroutine(CurrentStart());
            IEnumerator CurrentStart()
            {
                components.current_time = false;
                components.lap_animate.Play("lap_close");
                setting.playSound.clip = setting.audioClips[1]; setting.playSound.Play();
                yield return new WaitForSeconds(1f);
                components.plate_animate.Play("shake");
                setting.playSound.clip = setting.audioClips[2]; setting.playSound.Play();
                yield return new WaitForSeconds(2f);
                ShakeDices();
                yield return new WaitForSeconds(.2f);
                components.lap_animate.Play("lap_open");
                setting.playSound.clip = setting.audioClips[1]; setting.playSound.Play();
                yield return new WaitForSeconds(1f);
                StartCoroutine(instantiateDices.Instantiates(components.dice_values, sprites));
                yield return new WaitForSeconds(5f);
                EnableEffects();
                yield return new WaitForSeconds(.5f);
                components.plate_animate.Play("idle");
                components.dice_values.Clear();
                Array.Clear(sprites, 0, sprites.Length);
                components.current_time = true;
            }
        }
    }
    private void ShakeDices()
    {
        for (int dice = 0; dice < 3; dice++)
        {
            int dice_index = UnityEngine.Random.Range(0, 6);
            components.dice_values.Add(dice_index);
        }
        GetSpriteDicesToImage();
    }
    private void GetSpriteDicesToImage()
    {
        int add = 0;
        for (int value = 0; value < components.dice_values.Count; value++)
        {
            for (int sprite = 0; sprite < components.dice_sprites.Length; sprite++)
            {
                if (components.dice_values[value].Equals(sprite))
                {
                    components.dices[value].sprite = components.dice_sprites[sprite];
                    sprites[add] = components.normale_sprites[sprite];
                    components.board.GetChild(sprite).GetChild(0).gameObject.SetActive(true);
                    add++;
                    SetPointsOfDices(sprite);
                }
            }
        }
    }
    private void SetPointsOfDices(int index)
    {
        for (int point = 0; point < components.point_table.childCount; point++)
        {
            if (index.Equals(point))
            {
                components.dice_points[index]++;
                components.point_table.GetChild(index).GetChild(0).GetComponent<Text>().text = components.dice_points[index].ToString();
            }
        }
    }

    private void EnableEffects()
    {
        for (int effect = 0; effect < components.board.childCount; effect++)
        {
            components.board.GetChild(effect).GetChild(0).gameObject.SetActive(false);
        }
    }

}
