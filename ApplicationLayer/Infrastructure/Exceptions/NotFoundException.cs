namespace ApplicationLayer.Infrastructure.Exceptions
{
    internal class NotFoundException : Exception
    {
        public NotFoundException(Type type, object key)
        : base($"Модель типа \"{type.Name}\" с ключом ({key}) не найдена.")
        { }

        public NotFoundException(Type type)
            : base($"Модель типа \"{type.Name}\" не найдена.")
        { }
    }
}
