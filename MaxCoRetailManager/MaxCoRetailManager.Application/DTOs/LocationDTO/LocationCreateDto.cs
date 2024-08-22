namespace MaxCoRetailManager.Application.DTOs.LocationDTO;

public class LocationCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int? ParentLocationId { get; set; } = 0;


}

