using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDateTime : MonoBehaviour
{
    public static DateTime current_dateTime;
    public static string key_dateTime = "date-time";
    public static string key_point = "point";
    public static void SavePointAndTime(int[] ints)
    {
        current_dateTime = DateTime.Now;
        string string_dateTime = current_dateTime.ToLongDateString();
        PlayerPrefs.SetString(key_dateTime, string_dateTime);

        string array_string = string.Join(",", ints);
        PlayerPrefs.SetString(key_point, array_string);
    }

    public static int[] GetPoints()
    {
        string array_string = PlayerPrefs.GetString(key_point);
        string[] array_elements = array_string.Split(',');
        int[] table_point = new int[array_elements.Length];
        for (int i = 0; i < array_elements.Length; i++)
        {
            table_point[i] = int.Parse(array_elements[i]);
        }
        return table_point;
    }
}
