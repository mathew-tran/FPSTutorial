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
        if (go == null)
        {
            mText.text = "";
        }
        else
        {
            mText.text = go.name;
        }
           
    }
}
