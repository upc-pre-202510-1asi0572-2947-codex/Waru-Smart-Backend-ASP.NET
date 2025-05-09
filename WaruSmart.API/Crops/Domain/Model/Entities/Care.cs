using WaruSmart.API.Crops.Domain.Model.Aggregates;
using WaruSmart.API.Crops.Domain.Model.Commands;

namespace WaruSmart.API.Crops.Domain.Model.Entities;

public class Care
{
    public int Id { get; set; }

    public string Suggestion { get; set; }
    
    public DateTime Date { get; set; }
    
    public List<Crop> Crops { get; set; }

    public Care()
    {
        
    }
    
    public Care(string suggestion, DateTime date)
    {
       Suggestion = suggestion;
       Date= date;
    }
    public Care(CreateCareCommand command)
    {
        Suggestion = command.suggestion;
        Date = command.date;
    }

    
}