using UnityEngine;
using UnityEngine.UI;

public class LookAtUIText : MonoBehaviour
{
    public Text mText;

    private void Awake()
    {
        mText = GetComponent<Text>();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().OnObjectLookedAt.AddListener(OnPlayerLookedAtObject);
        mText.text = "";
    }

    public void OnPlayerLookedAtObject(GameObject go)
    {
        mText.text = go.name;
    }
}
