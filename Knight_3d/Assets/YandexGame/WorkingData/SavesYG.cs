
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money = 1;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения

        public int warriorCount = 0; // Количество воинов
        public int mageCount = 0;    // Количество магов

        // Конструктор для инициализации при первой загрузке
        public SavesYG()
        {
            
            openLevels[1] = true;

            warriorCount = 0;
            mageCount = 0;
        }
    }
}
