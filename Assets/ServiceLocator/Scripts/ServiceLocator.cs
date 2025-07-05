using System.Collections.Generic;

public class ServiceLocator
{
    // Словарь для хранения сервисов: ключ - тип сервиса, значение - сам объект сервиса
    private static Dictionary<System.Type, object> services = new Dictionary<System.Type, object>();

    /// <summary>
    /// Регистрирует (сохраняет) сервис в локаторе.
    /// </summary>
    /// <typeparam name="T">Тип сервиса</typeparam>
    /// <param name="service">Объект сервиса</param>
    public static void Register<T>(T service) where T : class
    {
        // Проверяем, есть ли уже такой сервис в словаре
        if (!services.ContainsKey(typeof(T)))
        {
            // Если нет — добавляем его
            services.Add(typeof(T), service);
        }
        else
        {
            // Если есть — можно обновить или выдать предупреждение
            // (в данном примере не реализовано)
        }
    }

    /// <summary>
    /// Возвращает зарегистрированный сервис указанного типа.
    /// </summary>
    /// <typeparam name="T">Тип запрашиваемого сервиса</typeparam>
    /// <returns>Сервис или null, если не найден</returns>
    public static T Resolve<T>() where T : class
    {
        // Получаем сервис по типу и приводим к нужному типу
        return services[typeof(T)] as T;
    }
}