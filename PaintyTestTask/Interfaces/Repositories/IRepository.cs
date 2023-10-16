namespace PaintyTestTask.Interfaces.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        //Проверяет есть ли сущность с указанным Id
        Task<bool> ExistId(int Id, CancellationToken Cancel = default);

        //Проверяет есть ли целиком сущность(Проверяет равенство двух сущностей по равенсту их ID)
        Task<bool> Exist(T item, CancellationToken Cancel = default);

        //Сколько всего сущностей
        Task<int> GetCount(CancellationToken Cancel = default);

        //Извлечь всё
        Task<IEnumerable<T>> GetAll(CancellationToken Cancel = default);

        //Извлекает всё, но есть возможность пропустить некоторое число в начале
        //и выбрать указанное кол-во значений
        Task<IEnumerable<T>> Get(int Skip, int Count, CancellationToken Cancel = default);

        //Постраничное разбиение (Указываем страницу и сколько на ней должно быть эл-ов)
        Task<IPage<T>> GetPage(int PageIndex, int PageSize, CancellationToken Cancel = default);

        //Найти сущность по Id(Возвращает null, если объект не найден)
        Task<T> GetById(int Id, CancellationToken Cancel = default);

        //Добавить объект в репозиторий
        Task<T> Add(T item, CancellationToken Cancel = default);

        //Внести изменния в сущность, хранимую в репозитории
        //(Будет возвращена сущность, которая хранилась в репозитори) / null
        Task<T> Update(T item, CancellationToken Cancel = default);

        //Удаление сущности из репозитория
        //(Будет возвращена сущность, которая хранилась в репозитори) / null
        Task<T> Delete(T item, CancellationToken Cancel = default);

        //Удаление сущности из репозитория по Id
        //(Будет возвращена сущность, которая хранилась в репозитори) / null
        Task<T> DeleteById(int Id, CancellationToken Cancel = default);


    }
    public interface IPage<T>
    {
        IEnumerable<T> Items { get; }
        //Всего эл-ов
        int TotalCount { get; }
        //Номер страницы
        int PageIndex { get; }
        //Размер страницы
        int PageSize { get; }
        //Полное кол-во страниц
        int TotalPagesCount => (int)Math.Ceiling((double)TotalCount / PageSize);
    }
}
