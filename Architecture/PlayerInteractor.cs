using UnityEngine;
using UnityEngine.PlayerLoop;

namespace TrainingArchitecture
{
    public class PlayerInteractor: Interaktor  // интерактор который знает об игроке и его переменных (Интерактор должен быть прописан в ScenConfigExample наследуемый от ScenConfigBase)
    {
        public Player _player { get; private set; } // ссылка на класс Player

        public override void Initialize() //Метод из базового класса
        {
            base.Initialize();
            var go = new GameObject("Player"); // Создаем игрока при инициализации (можно через ссылку на префаб в ресурсах)
            _player = go.AddComponent<Player>(); // добавляем компонент Player игроку
        }

      
        
    }
}