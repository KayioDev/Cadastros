using System.Text.Json;

public class ImagesService
{
    private readonly HttpClient _http; 

    public  ImagesService (HttpClient http) 
    {   
        _http = http ?? throw new ArgumentException(nameof(http));
    }

    public async Task<List<DogResponse>> PegarImagens()
    {
        string url = "https://picsum.photos/v2/list?page=1&limit=10";
        var response = await _http.GetFromJsonAsync<List<DogResponse>> (url);
        return response ?? new List<DogResponse>();
    }


}