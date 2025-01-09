using Ardalis.SharedKernel;

namespace DDFinancePolicy.Web;

public static class EndpointExtenssion
{
  /// <summary>
  /// Retrieves an aggregate, calls <see cref="Mapper{TRequest, TResponse, TEntity}"/> to update then maps result to response and responds.
  /// </summary>
  /// <typeparam name="TRequest">Request recieved by the API</typeparam>
  /// <typeparam name="TResponse">Response expected from the API</typeparam>
  /// <typeparam name="TMapper">The type of <see cref="Mapper{TRequest, TResponse, TResult}"/></typeparam>
  /// <typeparam name="T">The type domain entity to be updated</typeparam>
  /// <param name="edp">The Endpoint instance being extended</param>
  /// <param name="request">Request from the api.</param>
  /// <param name="Id">Request database identification</param>
  /// <param name="repository">An instatnce of the repository to allow the operations</param>
  /// <param name="cancellation">A <see cref="CancellationToken"/> to observe while waiting for the task to complete.</param>
  /// <returns>A task that represents the asynchronous operations.</returns>
  public static async Task SimpleUpdateAndRespondAsync<TRequest, TResponse, TMapper, T>(this Endpoint<TRequest, TResponse,
            TMapper> edp, TRequest request, int Id, IRepository<T> repository, CancellationToken cancellation)
    where TRequest : notnull where TResponse : notnull where TMapper : Mapper<TRequest, TResponse, T> where T : EntityBase, IAggregateRoot
  {
    var entityToUpdate = await repository.GetByIdAsync(Id, cancellation);
    if (entityToUpdate == null )
    {
      await edp.HttpContext.Response.SendNotFoundAsync(cancellation: cancellation);
      return;
    }

    var updatedEntity = edp.Map.UpdateEntity(request, entityToUpdate);
    await repository.UpdateAsync(updatedEntity, cancellation);
    var response = edp.Map.FromEntity(updatedEntity);
    await edp.HttpContext.Response.SendAsync(response, cancellation: cancellation);
  }
}
