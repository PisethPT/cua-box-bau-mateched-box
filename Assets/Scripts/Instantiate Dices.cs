using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InstantiateDices : MonoBehaviour
{
    public GameObject result_prefabs;
    public Setting setting;
    public GameObject display_panel;
    public Transform alert_table;
    public IEnumerator Instantiates(List<int> ints, params Sprite[] sprites)
    {
        display_panel.SetActive(true);
        for (int obj = 0; obj < ints.Count; obj++)
        {
            setting.playSound.clip = setting.audioClips[3]; setting.playSound.Play();
            var dice = Instantiate(result_prefabs.transform, alert_table);
            dice.GetComponent<Image>().sprite = sprites[obj];
            yield return new WaitForSeconds(1f);
        }
        yield return new WaitForSeconds(1f);
        for (int dice = 0; dice < alert_table.childCount; dice++)
        {
            Destroy(alert_table.GetChild(dice).gameObject);
        }
        display_panel.SetActive(false);
    }
}
