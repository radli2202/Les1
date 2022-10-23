using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TrainingArchitecture
{
    public class GameTestArchitect: MonoBehaviour
    {
    
        [SerializeField] private Text testTextCoin;

        private Player player;
        

        private void Start()
        {
            Game.Run();
            Game.OnGameInitializeEvent += OnGameInitialize; // Когда игра проинициализированна мы подписываемся на событие


            // testTextCoin.text = Bank.coins.ToString();

        }

        private void OnGameInitialize()
        {
            Game.OnGameInitializeEvent -= OnGameInitialize; //Отписываемся от события (иначе будут баги)
            var _playerInteractor = Game.GetInteractor<PlayerInteractor>(); // Так как GameTest (далее - ThisCs) не знает ничего про игрока,
                                                                            // а интерактор игрока знает про Player, мы достаем интерактор игрока
           this.player = _playerInteractor._player; //через интерактор игрока мы назначили ссылку на самого игрока который будет создан в сцене при старте игры
            
        }


private void Update()
{
    
    if(!Bank.IsInitialize) 
        return;
    if(this.player == null) return;
    Debug.Log($"Player Position: {player.transform.position}" ); // В каждом кадре выводим позицию Player
    
    
    if (Input.GetKeyDown(KeyCode.A))
    {
        BayCoin();
    }
    
    if (Input.GetKeyDown(KeyCode.S))
    {
        SaleCoin();
    }
}


// ReSharper disable Unity.PerformanceAnalysis
public void BayCoin()
        {
            Bank.AddCoins(this, 3);
            Debug.Log($"coin+3, {Bank.coins}" );

            testTextCoin.text = Bank.coins.ToString();
        }

// ReSharper disable Unity.PerformanceAnalysis
public void SaleCoin()
        {
            Bank.Spend(this, 3);
            Debug.Log($"coin-3, {Bank.coins}" );
            testTextCoin.text = Bank.coins.ToString();
        }

    }
}