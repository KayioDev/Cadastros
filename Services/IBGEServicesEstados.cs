namespace CadastroDeUsuarios.Services 
{
    public class IBGEService
{
    private readonly HttpClient _http;

    public IBGEService(HttpClient http)
    {
        _http = http;
    }
    public async Task<List<Estado>> ObterEstados()
    {
        string url = "https://servicodados.ibge.gov.br/api/v1/localidades/estados?orderBy=nome";
        var response = await _http.GetFromJsonAsync<List<Estado>>(url) ?? new List<Estado>();
        response.Sort((a , b) => string.Compare(a.Nome, b.Nome, StringComparison.OrdinalIgnoreCase));
        return response;
    }
}



}



