public class CidadeService
{
    private readonly HttpClient _http;

    public CidadeService(HttpClient http)
    {
        _http = http ?? throw new ArgumentNullException(nameof(http));
    }

    public async Task<List<Cidade>> ObterCidadesPorEstado(string uf)
    {
        if (string.IsNullOrEmpty(uf))
            return new List<Cidade>();

        string url = $"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{uf}/municipios";
        var response = await _http.GetFromJsonAsync<List<Cidade>>(url) ?? new List<Cidade>();
        return response;
    }
}


