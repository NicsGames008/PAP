using UnityEngine;

public class ShowSkill : MonoBehaviour
{
    public GameObject skill;

    public void ClickSkill()
    {
        skill.SetActive(!skill.activeSelf);
    }
}
