using UnityEngine;
using UnityEngine.UI;
using Unity.Services.Core;
using Unity.Services.Analytics;
using UnityEngine.Analytics;
public class DamageNum : MonoBehaviour
{
    private int number;
    public Image bossHealth;

    // Start is called before the first frame update
    async void Start()
    {
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
        // Initialize the number to 0 when the script starts
        number = 0;
    }


    public void AddOne()
    {
        number++;
    }
    void LateUpdate()
    {
        Debug.Log("bossg: " + bossHealth.fillAmount);
        if (bossHealth.fillAmount == 0)
        {
            Debug.Log("bossggggggggggg: " + number);
            gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {

        Debug.Log("content: " + number);
        CustomEvent myEvent = new CustomEvent("DamageToBossNum")
            {
                { "DamageNumber", number},
            };
        AnalyticsService.Instance.RecordEvent(myEvent);
    }

            

}
