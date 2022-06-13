using System;
using System.Collections.Generic;
using UnityEngine;

public class UpdateDisplayToCountReward : MonoBehaviour
{
    public static Action<List<int>> EventAddRewardPlayer { get; set; }
    public static Action<List<int>> EventRestResardPlayer { get; set; }
    [field: SerializeField] private GarageController _garageController { get; set; } //Прокинуть руками
    public List<List<int>> RewardToPlayer { get => _garageController.instanseSavePlayerState.RewardToPlayer; set => _garageController.instanseSavePlayerState.RewardToPlayer = value; }

    private void Awake()
    {
        EventAddRewardPlayer += AddRewardd;
        EventRestResardPlayer += RestToReward;
    }
    private void OnDestroy()
    {
        EventAddRewardPlayer -= AddRewardd;
        EventRestResardPlayer -= RestToReward;
    }
    private void AddRewardd(List<int> ListGetReward)
    {
        _garageController.instanseSavePlayerState.RewardToPlayer.Add(ListGetReward);
    }
    private void RestToReward(List<int> ListGetReward)
    {
        _garageController.instanseSavePlayerState.RewardToPlayer.Remove(ListGetReward);
    }
}
