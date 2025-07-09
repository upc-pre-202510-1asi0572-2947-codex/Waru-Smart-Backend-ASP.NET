using WaruSmart.API.Crops.Domain.Model.Commands;

namespace WaruSmart.API.Crops.Domain.Model.Aggregates;

public partial class Crop
{
    public int Id { get; private set; }
    public string Description { get; private set; }
    public string Name { get; private set; }
    
    public string ImageUrl { get; private set; }
    
    public ICollection<Sowing> Sowing { get; set; }


    protected Crop()
    {
        this.Name = string.Empty;
        this.Description = string.Empty;
        this.ImageUrl = string.Empty;
    }
    public Crop(string name, string imageUrl,string description)
    {
        Name = name;
        ImageUrl = imageUrl;
        Description = description;
    }
    public Crop(CreateCropCommand command)
    {
        this.Name = command.Name;
        this.Description = command.Description;
        this.ImageUrl = command.ImageUrl;

    }

    public Crop(UpdateCropCommand command)
    {
        this.Name = command.Name;
        this.Description = command.Description;
    }
    public void Update(string name, string description)
    {
        this.Name = name;
        this.Description = description;
    }
}