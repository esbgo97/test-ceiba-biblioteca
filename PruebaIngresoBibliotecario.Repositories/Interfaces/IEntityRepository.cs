namespace PruebaIngresoBibliotecario.Repositories.Interfaces
{
    public interface IEntityRepository<E>
    {
        Task<E> Save(E entity); 
        Task<List<E>> GetAll(E entityFilter);
        Task<bool> Update(E entity);
        Task<bool> Delete(E entity);
    }
}
