namespace ApiPokemon.Models
{
    public class PokemonDetalle
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public Sprites Sprites { get; set; }
        public List<ListaTipos> Types { get; set; }
    }

    public class ListaTipos
    {
        public Tipo Type { get; set; }
    }

    public class Tipo
    {
        public string Name { get; set; }
    }

    public class Sprites
    {
        public string Front_default { get; set; }
    }
}
