/*using WaruSmart.API.Crops.Domain.Model.Aggregates;
using WaruSmart.API.Crops.Domain.Model.Commands;

namespace WaruSmart.API.Crops.Domain.Model.Entities;

public class Pest
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public string Solution { get; set; }
    
    public List<Crop> Crops { get; set; }
    
    public Pest(int id, string name, string description, string solution)
    {
        Id = id;
        Name = name;
        Description = description;
        Solution = solution;
    }
    public Pest(CreatePestCommand command)
    {
        Name = command.Name;
        Description = command.Description;
        Solution = command.Solution;
    }
    
    public Pest()
    {
    }
}*/