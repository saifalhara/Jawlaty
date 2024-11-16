using Jawlaty.Models;

public interface IEntertainmentService
{
    IEnumerable<Entertainment> GetAllEntertainments();
    Entertainment GetEntertainmentById(int id);
    void AddEntertainment(Entertainment entertainment);
    void UpdateEntertainment(Entertainment entertainment);
    void DeleteEntertainment(int id);
    Task<List<Entertainment>> Search(string trem);
}