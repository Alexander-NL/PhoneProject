using UnityEngine;
using TMPro;

public class CurrencyUpdator : MonoBehaviour
{
    [SerializeField] private GameObject infoHolderObject;
    [SerializeField] private InfoHolder infoHolder;
    [SerializeField] TMP_Text CurrencyText;

    private void Start()
    {
        infoHolderObject = GameObject.Find("InfoHolder");
        infoHolder = infoHolderObject.GetComponent<InfoHolder>();
    }

    private void Update()
    {
        CurrencyText.text = $"{infoHolder.Currency}";
    }
}
