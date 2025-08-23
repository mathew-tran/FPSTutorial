using UnityEngine;
using TMPro;

public class LookAtUIText : MonoBehaviour
{
    public TextMeshProUGUI mText;

    private void Awake()
    {
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
