namespace _Tutorial
{
    public enum TutorialStep : byte
    {
        START = 0,
        PICK_MONEY = 1, // Подбираем деньги
        MOVE_TO_OTUS = 2, // Идем в OTUS
        BUY_TUTORIAL = 3, // Идем покупать курс UNITY (часть 1)
        WAITING_NEW_MONEY = 4, // Ждем когда придет зп
        PICK_NEW_MONEY = 5, // Подбираем новые деньги
        MOVE_TO_DIPLOMA = 6, // Опять идем в OTUS
        GET_DIPLOMA = 7, // Купить часть 2 (Получить диплом)
        MOVE_TO_PIZZA = 8, // Идем за питцей
        CLOSE_TUTORIAL = 9, // Закрываем окно туториала
        END = 19
    }
}