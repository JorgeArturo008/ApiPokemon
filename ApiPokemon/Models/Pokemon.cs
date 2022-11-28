namespace ApiPokemon.Models
{
    public class Pokemon 

    {
        public string? name { get; set; }
        public string? url { get; set; }

    }

    public class PokemonList
    {
        public List<Pokemon>? results;

    }

    public class PokemonType

    {
        public string? name { get; set; }
        public string? url { get; set; }

    }

    public class PokemonTypeList

    {
        public List<PokemonType>? resultstype;

    }
}
