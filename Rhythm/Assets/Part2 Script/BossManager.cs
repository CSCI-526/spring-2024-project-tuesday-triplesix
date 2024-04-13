using UnityEngine;
using UnityEngine.UI;
using Unity.Services.Core;
using Unity.Services.Analytics;
using UnityEngine.Analytics;
public class BossManager : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    private int DamageNum;
    public Image healthBarFill; // 血条填充的引用
    async void Start()
    {
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
        currentHealth = maxHealth;
        DamageNum = 0;
        UpdateHealthBar();
    }


    // 调用这个方法来给Boss造成伤害
    public void TakeDamage(float damage)
    {
        Debug.Log("Boss受到伤害：" + damage);
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // 防止生命值低于0或高于最大值
        UpdateHealthBar();
        DamageNum += 1;
        if (currentHealth == 0)
        {
            Debug.Log("content: " + DamageNum);
            CustomEvent myEvent = new CustomEvent("DamageToBossNum")
            {
                { "DamageNumber", DamageNum},
            };
            AnalyticsService.Instance.RecordEvent(myEvent);
        }
        
    }

    // 更新血条UI
    private void UpdateHealthBar()
    {
        healthBarFill.fillAmount = currentHealth / maxHealth;
    }
}
