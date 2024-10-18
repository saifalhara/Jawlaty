using Jawlaty.Models;
using System.Collections.Generic;

public interface ITransportationService
{
    IEnumerable<Transportation> GetAllTransportations();
    Transportation GetTransportationById(int id);
    void AddTransportation(Transportation transportation);
    void UpdateTransportation(Transportation transportation);
    void DeleteTransportation(int id);
    public IEnumerable<Transportation> GetTransportationByCityId(int cityId);

}
