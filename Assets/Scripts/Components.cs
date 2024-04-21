using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Components : MonoBehaviour
{
   public Image[] dices;
   public Sprite[] dice_sprites;
   public Sprite[] normale_sprites;
   public Transform point_table;
   public Transform board;
   public Transform noted;
   public int[] dice_points;
   public int[] history_points;
   public string date_time_text;
   public Animator plate_animate, lap_animate;
   [HideInInspector] public List<int> dice_values;
   [HideInInspector] public bool current_time = true;

}
